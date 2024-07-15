using SoBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace SoBlog.Domain.Entities.Blog
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(250)]
        public string DisplayTitle {  get; set; }

        [Required]
        [MaxLength(250)]
        public string SystemTitle {  get; set; }

        [Required]
        [MaxLength(50)]
        public string Color { get; set; }

        public ICollection<Post>? Posts { get; set; }    
    }
}
