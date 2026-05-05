using Microsoft.AspNetCore.Mvc;

namespace MVCProject.Controllers
{
    public class ProductController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
