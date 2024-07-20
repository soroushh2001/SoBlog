using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.DTOs.Categories
{
    public class ShowCategoryInIndex
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Image {  get; set; }
    }
}
