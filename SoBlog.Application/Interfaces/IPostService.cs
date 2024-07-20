using SoBlog.Domain.DTOs.Posts;
using SoBlog.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Application.Interfaces
{
    public interface IPostService 
    {
        Task<Post?> GetPostById(long id);
        Task<bool> CreatePost(AddPostDTO add, long authorId, string image);
        Task<EditPostDTO> FillEditPostdDTO(long postId);
        Task<bool> EditPost(EditPostDTO editPost, string? NewimageName=null);
        Task<FilterPostsForAdminDTO> FilterPostsForAdmin(FilterPostsForAdminDTO filterPostsForAdmin);   
        Task<bool> UnPublishedPost(long postId);
        Task<bool> PublishedPost(long postId);
		Task<IEnumerable<ShowAllPostInIndexDTO>> FillShowAllPostInIndexDTO();
        Task<ShowPostDetialDTO?> FillShowPostDetialDTOBySlug(string slug);
    }
}
