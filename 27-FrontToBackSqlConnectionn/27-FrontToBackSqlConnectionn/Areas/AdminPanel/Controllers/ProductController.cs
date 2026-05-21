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
                Tags=await _context.Tags.Where(t=>!t.IsDeleted).ToListAsync(),
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
            //foreach (var tId in productCreateVM.TagIDs)
            //{
            //    bool existTag = productCreateVM.Tags.Any(t=>t.Id==tId);
            //    if (!existTag)
            //    {
            //        ModelState.AddModelError(nameof(productCreateVM.TagIDs), "Tag does not exist");
            //        return View(productCreateVM);
            //    }
            //}
            if (productCreateVM.TagIDs is not null)
            {
                bool existTag = productCreateVM.TagIDs.Any(tagId => productCreateVM.Tags.Exists(t => t.Id == tagId));

                if (existTag)
                {
                    ModelState.AddModelError(nameof(productCreateVM.TagIDs), "Tag does not exist");
                    return View(productCreateVM);
                }
            }
            Product product = new()
            {
                Name = productCreateVM.Name,
                SKU = productCreateVM.SKU,
                Price = productCreateVM.Price,
                CategoryId = productCreateVM.CategoryId.Value
            };
            if (productCreateVM is not null)
            {
                product.ProductTags = productCreateVM.TagIDs.Select(tId => new ProductTag { TagId = tId }).ToList();
            }
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int?id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products.Include(p=>p.ProductTags).FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            ProductUpdateVM productUpdateVM = new ProductUpdateVM()
            {
                Name = product.Name,
                Price = product.Price,
                SKU = product.SKU,
                Description = product.Description,
                CategoryId = product.CategoryId,
                TagIDs = product.ProductTags.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync(),
            };
            return View(productUpdateVM);

        }
        [HttpPost]
        public async Task<IActionResult> Update(int ? id,ProductUpdateVM productUpdateVM)
        {
            if (id is null || id < 1) return BadRequest();

          

            productUpdateVM.Categories=await _context.Categories.Where(c=>!c.IsDeleted).ToListAsync();

            if (ModelState.IsValid)
            {
                return View(productUpdateVM);
            }

            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();
            bool existCategory=productUpdateVM.Categories.Any(c =>c.Id==productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(productUpdateVM.CategoryId),"category does not exist");
                return View(productUpdateVM);
            }
            product.Name = productUpdateVM.Name;
            product.Description = productUpdateVM.Description;
            product.SKU = productUpdateVM.SKU;
            product.Price= productUpdateVM.Price;
            product.CategoryId=productUpdateVM.CategoryId.Value;

            await _context.SaveChangesAsync();


            return RedirectToAction(nameof(Index));
        }
    }
}
