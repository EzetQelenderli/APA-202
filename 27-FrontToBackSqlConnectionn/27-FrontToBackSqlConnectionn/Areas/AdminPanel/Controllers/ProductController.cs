using _27_FrontToBackSqlConnectionn.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnectionn.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnectionn.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnectionn.Data;
using _27_FrontToBackSqlConnectionn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnectionn.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public ProductController(AppDbContext context,IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public async Task<IActionResult> Index()
        {


            List<ProductGetVM> productGetVMs = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => !p.IsDeleted)
                .Select(p=>new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SKU = p.SKU,
                    CategoryName = p.Category.Name,
                    Image = p.ProductImages.FirstOrDefault().Image
                })
                .ToListAsync();

    
            return View(productGetVMs);
        }
        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new ProductCreateVM()
            {
                Categories=await _context.Categories.Where(c=>!c.IsDeleted).ToListAsync(),
            };
            return View(productCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
            
        {
            productCreateVM.Categories=await _context.Categories.Where(c=>!!c.IsDeleted).ToListAsync();
            if (!ModelState.IsValid) return View(productCreateVM);
            bool existCategory=productCreateVM.Categories.Any(c => c.Id==productCreateVM.CategoryId);

            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "category dont exist");

                return View(productCreateVM);
            }


            return View(productCreateVM);
        }
    }
}
