using SoBlog.Domain.Entities.Account;
using SoBlog.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoBlog.Domain.Entities.Blog
{
    public class Post : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Slug { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        public long AuthorId { get; set; }
        [ForeignKey(nameof(AuthorId))]
        public User? Author { get; set; }

        [Required]
        public int TimeToRead { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        [MaxLength(50)]
        public string ImageName { get; set; }                                                                           

        public bool IsPinned { get; set; }

        public bool IsProposed {  get; set; }

        public bool IsPublished {  get; set; }
        
        public DateTime? PublishDate { get; set; }

        public long CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]    
        public Category? Category { get; set; } 


        public ICollection<Comment>? Comments { get; set; }
        public ICollection<PostTag>? PostTags { get; set; }  
    }
}
