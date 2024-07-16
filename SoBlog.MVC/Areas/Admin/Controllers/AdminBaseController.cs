using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
    public class AdminBaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";
		protected string WarningMessage = "WarningMessage";
		protected string ErrorMessage = "ErrorMessage";
		protected string InfoMessage = "InfoMessage";
	}
}
