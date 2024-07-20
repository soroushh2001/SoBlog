namespace SoBlog.Domain.DTOs.Posts
{
	public class ShowPostDetialDTO
	{
		public long Id { get; set; }
		public string ImageName {  get; set; }
		public string CategoryTitle {  get; set; }
		public string Title { get; set; }
		public string AuthorName { get; set; }
		public DateTime? PublishedDate { get; set; }
		public string AuthorAvatar {  get; set; }
		public int TimeToRead {  get; set; }
		public string Text { get; set; }
		public string? AuthorJob {  get; set; }
		public string? AuthorDescription {  get; set; }
	}
}
