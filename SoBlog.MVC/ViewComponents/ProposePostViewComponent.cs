using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Interfaces;

namespace SoBlog.MVC.ViewComponents
{
    public class ProposePostViewComponent : ViewComponent
    {
        private readonly IPostService _postService;
        public ProposePostViewComponent(IPostService postService)
        {
            _postService = postService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var post = await _postService.FillShowAllPostInIndexDTO();
            post = post.Where(p => p.IsPublished && p.IsProposed);
            return View("ProposePost", post);
        }
    }
}
