using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnectionn.Areas.AdminPanel.Controllers
{
    public class DashboardController : Controller
    {
        [Area("AdminPanel")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
