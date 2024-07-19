using Microsoft.EntityFrameworkCore;
using SoBlog.Domain.Entities.Blog;
using SoBlog.Domain.Interfaces;
using SoBlog.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<Post?> GetPostById(long id)
        {
            return await _context.Posts.SingleOrDefaultAsync(u => u.Id == id);
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
