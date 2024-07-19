using Microsoft.AspNetCore.Mvc;
using SoBlog.Application.Extensions;
using SoBlog.Application.Statics;
using SoBlog.MVC.SiteExtensions;

namespace SoBlog.MVC.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("AddToServer")]
        public IActionResult UploadEditorImage(IFormFile file)
        {
            
            var fileName = Guid.NewGuid().ToString("N") + Path.GetExtension(file.FileName);

            file.UploadFile(fileName, PathTools.UploadEditorServerPath);


            return Ok(new { location = $"{PathTools.UploadEditorPath}" + fileName });
        }
    }
}
