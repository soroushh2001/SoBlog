using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SoBlog.Application.Extensions;
using SoBlog.Application.Interfaces;
using SoBlog.Application.Statics;
using SoBlog.Domain.DTOs.Posts;
using SoBlog.MVC.SiteExtensions;

namespace SoBlog.MVC.Areas.Admin.Controllers
{
    public class PostController : AdminBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        private readonly ITagService _tagService;
        public PostController(ICategoryService categoryService, IPostService postService, ITagService tagService)
        {
            _categoryService = categoryService;
            _postService = postService;
            _tagService = tagService;
        }

        [HttpGet("posts")]
        public async Task<IActionResult> Index(FilterPostsForAdminDTO filter)
        {
            filter.TakeEntity = 1;
            return View(await _postService.FilterPostsForAdmin(filter));
        }

        [HttpGet("posts/add")]
        public async Task<IActionResult> AddPost()
        {
            var categories = await _categoryService.GetAllCategories();
            ViewData["Categories"] = categories.Select(c => new SelectListItem
            {
                Text = c.DisplayTitle,
                Value = c.Id.ToString()
            }).ToList();

            var tags = await _tagService.GetAllTags();

            ViewData["Tags"] = tags.Select(t => new SelectListItem
            {
                Text = t.DisplayTitle,
                Value = t.DisplayTitle
            }).ToList();

            return View();
        }

        [HttpPost("posts/add")]
        public async Task<IActionResult> AddPost(AddPostDTO addPost, IFormFile image)
        {
            if (ModelState.IsValid)
            {
                string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(image.FileName);
                image.UploadFile(imageName, PathTools.PostImageSreverPath);
           

                var result = await _postService.CreatePost(addPost, HttpContext.User.GetUserId(),imageName);

                if (result)
                {
                    TempData[SuccessMessage] = "پست جدید ساخته شد";
                    return RedirectToAction("Index");
                }
                return View(addPost);

            }
            return View(addPost);
        }


        [HttpGet("posts/edit/{id}")]
        public async Task<IActionResult> EditPost(long id)
        {
            var categories = await _categoryService.GetAllCategories();
            ViewData["Categories"] = categories.Select(c => new SelectListItem
            {
                Text = c.DisplayTitle,
                Value = c.Id.ToString()
            }).ToList();

            var tags = await _tagService.GetAllTags();

            ViewData["Tags"] = tags.Select(t => new SelectListItem
            {
                Text = t.DisplayTitle,
                Value = t.DisplayTitle
            }).ToList();
            
            var edit = await _postService.FillEditPostdDTO(id);
            ViewBag.Referer = HttpContext.Request.Headers.Referer;
            return View(edit);
        }

        [HttpPost("posts/edit/{id}")]
        public async Task<IActionResult> EditPost(EditPostDTO edit, IFormFile? image, string? referer)
        {
            if (ModelState.IsValid)
            {
                if (image == null)
                {
                    await _postService.EditPost(edit);

                    TempData[SuccessMessage] = "پست با موفقیت ویرایش شد";
                    return Redirect(referer);
                }
                else
                {
                    var post = await _postService.GetPostById(edit.Id);
                    var oldImage = PathTools.PostImageSreverPath + image.FileName;
                    if (System.IO.File.Exists(oldImage)) 
                    {
                        System.IO.File.Delete(oldImage);    
                    }

                    string imageName = Guid.NewGuid().ToString("N") + Path.GetExtension(image.FileName);
                    image.UploadFile(imageName, PathTools.PostImageSreverPath);

                    await _postService.EditPost(edit, imageName);

                    return Redirect(referer);

                }
            }

            var categories = await _categoryService.GetAllCategories();
            ViewData["Categories"] = categories.Select(c => new SelectListItem
            {
                Text = c.DisplayTitle,
                Value = c.Id.ToString()
            }).ToList();

            var tags = await _tagService.GetAllTags();

            ViewData["Tags"] = tags.Select(t => new SelectListItem
            {
                Text = t.DisplayTitle,
                Value = t.DisplayTitle
            }).ToList();
            return View(edit);
        }

        [HttpGet("unpublished-post")]
        public async Task<IActionResult> UnpublishedPost(long postId)
        {
            var result = await _postService.UnPublishedPost(postId);

            if (result) return new JsonResult(new { status = "success" });

            return new JsonResult(new { status = "error" });
        }

		[HttpGet("published-post")]
		public async Task<IActionResult> PublishedPost(long postId)
		{
			var result = await _postService.PublishedPost(postId);

			if (result) return new JsonResult(new { status = "success" });

			return new JsonResult(new { status = "error" });
		}

	}
}
