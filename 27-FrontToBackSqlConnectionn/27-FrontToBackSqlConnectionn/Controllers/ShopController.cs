using _27_FrontToBackSqlConnectionn.Services;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnectionn.Controllers
{
    public class ShopController:Controller
    {
        private readonly IEmailService _emailService;

        public ShopController(IEmailService emailService)
        {
            _emailService=emailService;
        }
        public IActionResult Index()
        {
            _emailService.SendEmail();
            return View();
        }
    }
}
