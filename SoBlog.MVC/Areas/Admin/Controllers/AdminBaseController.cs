using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SoBlog.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin")]
	[Authorize]
    public class AdminBaseController : Controller
	{
		protected string SuccessMessage = "SuccessMessage";
		protected string WarningMessage = "WarningMessage";
		protected string ErrorMessage = "ErrorMessage";
		protected string InfoMessage = "InfoMessage";
	}
}
