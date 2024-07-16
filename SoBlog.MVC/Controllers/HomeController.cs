using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Controllers
{
	public class HomeController : BaseController
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
