using SoBlog.Domain.DTOs.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.DTOs.Posts
{
    public class FilterPostsForAdminDTO : Paging<ShowPostAdminDTO>
    {
        public string? Title { get; set; }

        public ShowState? State { get; set; }

    }

    public enum ShowState
    {
        [Display(Name ="همه")]
        All,
        [Display(Name = "قدیمی ترین")]
        Oldest,
        [Display(Name = "جدیدترین")]
        Newest,
        [Display(Name = "منتشر شده")]
        Published,
        [Display(Name = "منتشر نشده")]
        UnPublished
    }

}
