using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.DTOs.Posts
{
    public class ShowPostAdminDTO
    {
        public long Id { get; set; }
        public string Title {  get; set; }
        public string? AuthorName { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime? PublishDate {  get; set; }
        public string Categroy {  get; set; }
        public string CategroyColor { get; set; }
        public bool Status { get; set; }
    }
}
