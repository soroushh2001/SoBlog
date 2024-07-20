using Microsoft.EntityFrameworkCore;
using SoBlog.Domain.Entities.Blog;
using SoBlog.Domain.Interfaces;
using SoBlog.Infra.Data.Context;

namespace SoBlog.Infra.Data.Repositories
{
	public class PostRepository : IPostRepository
    {
        private readonly SoBlogDbContext _context;
        public PostRepository(SoBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Post>> GetAllPosts()
        {
            return _context.Posts.Include(p => p.Category).Include(p=> p.Author).AsQueryable();
        }

        public async Task<IEnumerable<Post>?> GetAllPinnedPost()
        {
            return await _context.Posts.Where(p => p.IsPinned).Include(p => p.Category).Include(p=> p.Author).ToListAsync();
        }

		public async Task<Post?> GetPostById(long id)
        {
            return await _context.Posts.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<Post?> GetPostBySlug(string slug)
        {
            return await _context.Posts.Include(p => p.Author).Include(p => p.Category).SingleOrDefaultAsync(p => p.Slug == slug);
        }

		public async Task AddPost(Post post)
        {
            await _context.Posts.AddAsync(post);
        }

        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
