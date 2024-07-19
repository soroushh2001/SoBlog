using SoBlog.Application.Extensions;
using SoBlog.Application.Interfaces;
using SoBlog.Domain.DTOs.Posts;
using SoBlog.Domain.Entities.Blog;
using SoBlog.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ITagRepository _tagRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ICategoryRepository _categoryRepository;
        public PostService(IPostRepository postRepository, ITagRepository tagRepository, IAccountRepository accountRepository, ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _accountRepository = accountRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<Post?> GetPostById(long id)
        {
            return await _postRepository.GetPostById(id);
        }

        public async Task<bool> CreatePost(AddPostDTO add, long authorId, string image)
        {

            var newPost = new Post
            {
                AuthorId = authorId,
                CategoryId = add.CategoryId,
                CreatedDate = DateTime.Now,
                IsPinned = add.IsPinned,
                Slug = add.Slug,
                IsProposed = add.IsProposed,
                TimeToRead = add.TimeToRead,
                Title = add.Title,
                Text = add.Text,
                ImageName = image
            };

            if (add.IsPublished)
            {
                newPost.PublishDate = DateTime.Now;
            }

            await _postRepository.AddPost(newPost);
            await _postRepository.SaveChanges();

            foreach(var tag in add.Tags)
            {
                if (!await _tagRepository.IsTagExitedByTitle(tag))
                {
                    var newTag = new Tag
                    {
                        DisplayTitle = tag
                    };
                    await _tagRepository.AddTag(newTag);
                    await _tagRepository.SaveChanges();
                }

                var newPostTag = new PostTag
                {
                    PostId = newPost.Id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    TagId = await _tagRepository.GetTagIdByTitle(tag)
                };
                await _tagRepository.AddPostTag(newPostTag);
            }
            await _tagRepository.SaveChanges();

            return true;
        }

        public async Task<EditPostDTO> FillEditPostdDTO(long postId)
        {
            var post = await _postRepository.GetPostById(postId);
            return new EditPostDTO
            {
                Id = postId,
                CategoryId = post.CategoryId,
                IsPinned = post.IsPinned,
                IsProposed = post.IsProposed,
                Slug = post.Slug,
                Tags = await _tagRepository.GetPostTagsNameByPostId(postId),
                Text = post.Text,
                TimeToRead = post.TimeToRead,
                Title = post.Title,
                AuthorId = post.AuthorId,
                ImageName = post.ImageName,
                IsPublished = post.IsPublished
            };
        }

        public async Task<bool> EditPost(EditPostDTO editPost, string? NewimageName = null)
        {
            var getPost = await _postRepository.GetPostById(editPost.Id);

            if (getPost == null) return false;

            getPost.Title = editPost.Title;
            getPost.IsPinned = editPost.IsPinned;
            getPost.AuthorId = editPost.AuthorId;
            getPost.IsProposed = editPost.IsProposed;
            getPost.CategoryId = editPost.CategoryId;
            getPost.Slug = editPost.Slug;
            getPost.UpdatedDate = DateTime.Now;
            getPost.Text = editPost.Text;
            getPost.TimeToRead = editPost.TimeToRead;
            getPost.IsPublished = editPost.IsPublished;

            if (getPost.IsPublished)
            {
                getPost.PublishDate = DateTime.Now;
            }

            if (NewimageName == null)
            {
                   getPost.ImageName = editPost.ImageName;
            }
            else
            {
                getPost.ImageName = NewimageName;
            }

            _postRepository.UpdatePost(getPost);
            await _postRepository.SaveChanges();


            //DeleteTags
            _tagRepository.RemoveAllPostTags(editPost.Id);
            await _tagRepository.SaveChanges();

            foreach (var tag in editPost.Tags)
            {
                if (!await _tagRepository.IsTagExitedByTitle(tag))
                {
                    var newTag = new Tag
                    {
                        DisplayTitle = tag
                    };
                    await _tagRepository.AddTag(newTag);
                    await _tagRepository.SaveChanges();
                }

                var newPostTag = new PostTag
                {
                    PostId = getPost.Id,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    TagId = await _tagRepository.GetTagIdByTitle(tag)
                };
                await _tagRepository.AddPostTag(newPostTag);
            }
            await _tagRepository.SaveChanges();


            return true;
        }

        
        public async Task<FilterPostsForAdminDTO> FilterPostsForAdmin(FilterPostsForAdminDTO filterPostsForAdmin)
        {
            var query = await _postRepository.GetAllPosts();

            if (!string.IsNullOrEmpty(filterPostsForAdmin.Title))
            {
                query = query.Where(q => q.Title.Contains(filterPostsForAdmin.Title));  
            }

            switch (filterPostsForAdmin.State)
            {
                case ShowState.All:
                    break;
                case ShowState.Oldest:
                   query = query.OrderBy(c => c.UpdatedDate);
                    break;
                case ShowState.Newest:
                   query = query.OrderByDescending(c => c.UpdatedDate);
                    break;
                case ShowState.Published:
                   query = query.Where(u => u.IsPublished);
                    break;
                case ShowState.UnPublished:
                    query = query.Where(u =>  !u.IsPublished);
                    break;
            }

            var result = query
                .Select(p => new ShowPostAdminDTO 
                {
                    Id = p.Id,
                    AuthorName = p.Author.FullName,
                    Categroy = p.Category.DisplayTitle,
                    CreateDate = p.CreatedDate,
                    CategroyColor = p.Category.Color,
                    PublishDate = p.PublishDate,
                    Status = p.IsPublished,
                    Title = p.Title,
                    UpdateDate = p.UpdatedDate
                }).AsQueryable();
           await filterPostsForAdmin.SetPaging(result);
            return filterPostsForAdmin;
        }

        public async Task<bool> UnPublishedPost(long postId)
        {
            var getPost = await GetPostById(postId);
            if (getPost == null) return false;
            getPost.IsPublished = false;
            _postRepository.UpdatePost(getPost);
            await _postRepository.SaveChanges();
            return true;
        }

        public async Task<bool> PublishedPost(long postId)
        {
            var getPost = await GetPostById(postId);
            if (getPost == null) return false;
            getPost.IsPublished = true;
            _postRepository.UpdatePost(getPost);
            await _postRepository.SaveChanges();
            return true;
        }


	}
}
