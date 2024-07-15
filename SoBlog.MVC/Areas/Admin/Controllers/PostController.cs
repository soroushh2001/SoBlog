using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Areas.Admin.Controllers
{
	public class PostController : AdminBaseController
	{
		[HttpGet("posts")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
