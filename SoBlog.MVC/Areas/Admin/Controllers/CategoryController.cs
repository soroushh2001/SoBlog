using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Areas.Admin.Controllers
{
	public class CategoryController : AdminBaseController
	{
		[HttpGet("categories")]
		public IActionResult Index()
		{
			return View();
		}

		[HttpGet("categories/add")]
		public IActionResult AddCategory()
		{
			return View();
		}
	}
}
