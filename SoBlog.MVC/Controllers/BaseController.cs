using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Controllers
{
	public class BaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";
		protected string WarningMessage = "WarningMessage";
		protected string ErrorMessage = "ErrorMessage";
		protected string InfoMessage = "InfoMessage";
	}
}
