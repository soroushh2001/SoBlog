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
    public class TagRepository : ITagRepository
    {
        private readonly SoBlogDbContext _context;
        public TagRepository(SoBlogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Tag>> GetAllTags()
        {
            return await _context.Tags.ToListAsync();
        }

        public async Task<bool> IsTagExitedByTitle(string title)
        {
            return await _context.Tags.AnyAsync(t => t.DisplayTitle == title);
        }

        public async Task<Tag?> GetTagByTitle(string title)
        {
            return await _context.Tags.FirstOrDefaultAsync(u => u.DisplayTitle == title);
        }

        public async Task<long> GetTagIdByTitle(string title)
        {
            var tag = await GetTagByTitle(title);
            return tag.Id;
        }

        public async Task<List<string>> GetPostTagsNameByPostId(long postId)
        {
          return await _context.PostTags.Where(p => p.PostId == postId).Include(u => u.Tag).Select(a=> a.Tag.DisplayTitle).ToListAsync();
        }

        public void RemoveAllPostTags(long postId)
        {
            _context.PostTags.RemoveRange(_context.PostTags.Where(pt => pt.PostId == postId));
        }

        public async Task AddTag(Tag tag)
        {
            await _context.Tags.AddAsync(tag);
        }

        public async Task AddPostTag(PostTag postTag)
        {
            await _context.PostTags.AddAsync(postTag);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
