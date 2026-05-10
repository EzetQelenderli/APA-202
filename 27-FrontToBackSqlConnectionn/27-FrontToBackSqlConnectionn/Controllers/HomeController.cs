using _27_FrontToBackSqlConnectionn.Data;
using _27_FrontToBackSqlConnectionn.Models;
using _27_FrontToBackSqlConnectionn.Services;
using _27_FrontToBackSqlConnectionn.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnectionn.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public HomeController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            List<Product> products = _context.Products
                .Include(p => p.ProductImages)
                .Where(p => !p.IsDeleted)
                .ToList();

            _emailService.SendEmail();

            List<Slider> sliders = _context.Sliders
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                .Take(2)
                .ToList();

            HomeVM homeVM = new HomeVM()
            {
                Sliders = sliders,
                Products = products
            };

            return View(homeVM);
        }
    }
}