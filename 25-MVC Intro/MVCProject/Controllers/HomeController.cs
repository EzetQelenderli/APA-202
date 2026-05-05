using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            //return Content("APA202");
            //var Student = new JsonResult(new { id = 1, name = "Ali", surname = "quliyev" });
            return View("Index");
        }
        public IActionResult Detail(int? id)
        {
            if (id is null || id < 1)
            {
                return RedirectToAction(nameof(Error));
            }
            return RedirectToAction(nameof(Index),"Product");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}
