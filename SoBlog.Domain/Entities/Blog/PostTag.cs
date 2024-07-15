using SoBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoBlog.Domain.Entities.Blog
{
    public class PostTag : BaseEntity
    {
        public long TagId {  get; set; }
        [ForeignKey(nameof(TagId))] 
        public Tag? Tag { get; set; }

        public long PostId { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post? Post { get; set; } 
    }
}
