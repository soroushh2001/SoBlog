using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
