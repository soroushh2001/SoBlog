using SoBlog.Domain.Entities.Blog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllTags();
        Task<bool> IsTagExitedByTitle(string title);
        Task<Tag?> GetTagByTitle(string title);
        Task<long> GetTagIdByTitle(string title);
        Task<List<string>> GetPostTagsNameByPostId(long postId);
        void RemoveAllPostTags(long postId);
        Task AddTag(Tag tag);
        Task AddPostTag(PostTag postTag);
        Task SaveChanges();
    }
}
