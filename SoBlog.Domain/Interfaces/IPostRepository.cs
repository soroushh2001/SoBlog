using SoBlog.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task<IQueryable<Post>> GetAllPosts();
        Task<Post?> GetPostById(long id);
        Task AddPost(Post post);
        void UpdatePost(Post post);
        Task SaveChanges();
    }
}
