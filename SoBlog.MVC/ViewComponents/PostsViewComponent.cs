using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Interfaces;

namespace SoBlog.MVC.ViewComponents
{
	public class PostsViewComponent : ViewComponent
	{
		private readonly IPostService _postService;
		public PostsViewComponent(IPostService postService)
		{
			_postService = postService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var allPosts = await _postService.FillShowAllPostInIndexDTO();

			allPosts = allPosts.Where(u => u.IsPublished).OrderByDescending(u => u.PublishDate).Take(6);

			return View("Posts",allPosts);	
		}
	}
}
