using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoBlog.Domain.DTOs.Posts
{
	public class ShowAllPostInIndexDTO
	{
		public long Id { get; set; }
		public string Title { get; set; }
		public string Slug { get; set; }
		public string? AuthorName { get; set; }
		public string Categroy { get; set; }
		public string CategorySystemName { get; set; }
		public string CategroyColor { get; set; }
		public string ImageUrl { get; set; }
		public DateTime? PublishDate { get; set; }
		public bool IsPublished { get; set; }
		public bool IsPinned { get; set; }
		public string AuthorAvatar { get; set; }
		public bool IsProposed { get; set; }
		
	}
}
