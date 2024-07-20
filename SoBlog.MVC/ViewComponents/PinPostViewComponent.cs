using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Interfaces;

namespace SoBlog.MVC.ViewComponents
{
    public class PinPostViewComponent : ViewComponent
    {
        private readonly IPostService _postService;
        public PinPostViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var pinnedPost = await _postService.FillShowAllPostInIndexDTO();
            pinnedPost = pinnedPost.Where(c => c.IsPublished && c.IsPinned).OrderByDescending(c => c.PublishDate).Take(9);
			return View("PinPost", pinnedPost);                                                                              
        }
    }
}
