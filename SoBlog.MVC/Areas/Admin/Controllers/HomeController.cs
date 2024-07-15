using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        [HttpGet("dashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
