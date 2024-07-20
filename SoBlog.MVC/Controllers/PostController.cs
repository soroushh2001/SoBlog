using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Interfaces;

namespace SoBlog.MVC.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet("posts/{CategorySystemName}/{postSlug}")]
        public async Task<IActionResult> ShowPostDetilas(string categorySystemName, string postSlug)
        {
            if (await _postService.FillShowPostDetialDTOBySlug(postSlug) == null)
            {
                return NotFound();
            }

            return View(await _postService.FillShowPostDetialDTOBySlug(postSlug));
        }
    }
}
