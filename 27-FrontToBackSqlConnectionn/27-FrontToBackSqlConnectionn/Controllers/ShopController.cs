using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnectionn.Controllers
{
    public class ShopController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
