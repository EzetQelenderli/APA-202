using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnectionn.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnectionn.Data;
using _27_FrontToBackSqlConnectionn.Models;
using _27_FrontToBackSqlConnectionn.Utilities.Enums;
using _27_FrontToBackSqlConnectionn.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> productGetVMs = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Where(p => !p.IsDeleted)
                .Select(p => new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SKU = p.SKU,
                    CategoryName = p.Category.Name,
                    Image = p.ProductImages.FirstOrDefault(p => p.IsPrimary == true).Image
                })
                .ToListAsync();

            return View(productGetVMs);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync()
            };

            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            if (!productCreateVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File type is incorrect!");
                return View(productCreateVM);
            }
            if (!productCreateVM.MainPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File size must be lees than 2mb!");
                return View(productCreateVM);
            }


            if (!productCreateVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File type is incorrect!");
                return View(productCreateVM);
            }
            if (!productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File size must be lees than 2mb!");
                return View(productCreateVM);
            }


            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);

            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category does not exist!");
                return View(productCreateVM);
            }

            if (productCreateVM.TagIds is not null)
            {
                bool existTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
                if (existTag)
                {
                    ModelState.AddModelError(nameof(productCreateVM.TagIds), "Tags does not exist!");
                    return View(productCreateVM);
                }
            }

            ProductImage mainImage = new()
            {
                Image = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = true,
            };

            ProductImage hoverImage = new()
            {
                Image = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false,
            };


            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Description = productCreateVM.Description,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
                ProductImages = new List<ProductImage> { mainImage, hoverImage }
            };

            if (productCreateVM.TagIds is not null)
            {
                product.ProductTags = productCreateVM.TagIds.Select(tId => new ProductTag { TagId = tId }).ToList();
            }


            if (productCreateVM.AdditionalPhotos is not null)
            {
                string text = string.Empty;
                foreach (IFormFile file in productCreateVM.AdditionalPhotos)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} type was not correct</p>";
                        continue;
                    }
                    if (!file.CheckFileSize(FileSize.KB, 100))
                    {
                        text += $"<p class=\"text-danger\">{file.FileName} size was not correct</p>";
                        continue;
                    }

                    product.ProductImages.Add(new ProductImage
                    {
                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null
                    });
                }

                TempData["FileWarning"] = text;
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = product.Name,
                Price = product.Price,
                SKU = product.SKU,
                Description = product.Description,
                CategoryId = product.CategoryId,
                TagIds = product.ProductTags.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync(),
                ProductImages = product.ProductImages,
            };

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            
                if (id is null || id < 1) return BadRequest();

                Product? product = await _context.Products
                    .Include(p => p.ProductImages)
                    .Include(p => p.ProductTags)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (product is null) return NotFound();

                productUpdateVM.Categories = await _context.Categories
                    .Where(c => !c.IsDeleted)
                    .ToListAsync();

                productUpdateVM.Tags = await _context.Tags
                    .Where(t => !t.IsDeleted)
                    .ToListAsync();

                productUpdateVM.ProductImages = product.ProductImages;

                if (!ModelState.IsValid)
                {
                    return View(productUpdateVM);
                }

                if (productUpdateVM.MainPhoto is not null)
                {
                    if (!productUpdateVM.MainPhoto.CheckFileType("image/"))
                    {
                        ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File type is incorrect!");
                        return View(productUpdateVM);
                    }

                    if (!productUpdateVM.MainPhoto.CheckFileSize(FileSize.MB, 1))
                    {
                        ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File size must be less than 1mb!");
                        return View(productUpdateVM);
                    }
                }

                if (productUpdateVM.HoverPhoto is not null)
                {
                    if (!productUpdateVM.HoverPhoto.CheckFileType("image/"))
                    {
                        ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File type is incorrect!");
                        return View(productUpdateVM);
                    }

                    if (!productUpdateVM.HoverPhoto.CheckFileSize(FileSize.MB, 1))
                    {
                        ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File size must be less than 1mb!");
                        return View(productUpdateVM);
                    }
                }

                bool existCategory = productUpdateVM.Categories
                    .Any(c => c.Id == productUpdateVM.CategoryId);

                if (!existCategory)
                {
                    ModelState.AddModelError(nameof(productUpdateVM.CategoryId), "Category does not exist!");
                    return View(productUpdateVM);
                }

                if (productUpdateVM.TagIds is not null)
                {
                    bool existTag = productUpdateVM.TagIds
                        .Any(tagId => !productUpdateVM.Tags.Exists(t => t.Id == tagId));

                    if (existTag)
                    {
                        ModelState.AddModelError(nameof(productUpdateVM.TagIds), "Tag does not exist!");
                        return View(productUpdateVM);
                    }
                }

                if (productUpdateVM.TagIds is null)
                {
                    productUpdateVM.TagIds = new();
                }

                _context.ProductTags.RemoveRange(
                    product.ProductTags
                    .Where(pTag => !productUpdateVM.TagIds
                    .Exists(tId => tId == pTag.TagId))
                    .ToList()
                );

                _context.ProductTags.AddRange(
                    productUpdateVM.TagIds
                    .Where(tId => !product.ProductTags
                    .Exists(pTag => pTag.TagId == tId))
                    .Select(tId => new ProductTag
                    {
                        TagId = tId,
                        ProductId = product.Id
                    })
                    .ToList()
                );

                if (productUpdateVM.MainPhoto is not null)
                {
                    string fileName = await productUpdateVM.MainPhoto.CreateFile(
                        _env.WebRootPath,
                        "assets",
                        "images",
                        "website-images"
                    );

                    ProductImage? mainImage = product.ProductImages
                        .FirstOrDefault(p => p.IsPrimary == true);

                    if (mainImage is not null)
                    {
                        product.ProductImages.Remove(mainImage);

                        mainImage.Image.DeleteFile(
                            _env.WebRootPath,
                            "assets",
                            "images",
                            "website-images"
                        );
                    }

                    product.ProductImages.Add(new ProductImage
                    {
                        Image = fileName,
                        IsPrimary = true,
                    });
                }

                if (productUpdateVM.HoverPhoto is not null)
                {
                    string fileName = await productUpdateVM.HoverPhoto.CreateFile(
                        _env.WebRootPath,
                        "assets",
                        "images",
                        "website-images"
                    );

                    ProductImage? hoverImage = product.ProductImages
                        .FirstOrDefault(p => p.IsPrimary == false);

                    if (hoverImage is not null)
                    {
                        product.ProductImages.Remove(hoverImage);

                        hoverImage.Image.DeleteFile(
                            _env.WebRootPath,
                            "assets",
                            "images",
                            "website-images"
                        );
                    }

                    product.ProductImages.Add(new ProductImage
                    {
                        Image = fileName,
                        IsPrimary = false,
                    });
                }

                if (productUpdateVM.ImageIds is null)
                {
                    productUpdateVM.ImageIds = new List<int>();
                }

                var deletedImages = product.ProductImages
                    .Where(pi =>
                        !productUpdateVM.ImageIds.Exists(imgId => imgId == pi.Id)
                        && pi.IsPrimary == null)
                    .ToList();

                deletedImages.ForEach(di =>
                    di.Image.DeleteFile(
                        _env.WebRootPath,
                        "assets",
                        "images",
                        "website-images"
                    )
                );

                _context.ProductImages.RemoveRange(deletedImages);

                if (productUpdateVM.AdditionalPhotos is not null)
                {
                    string text = string.Empty;

                    foreach (IFormFile file in productUpdateVM.AdditionalPhotos)
                    {
                        if (!file.CheckFileType("image/"))
                        {
                            text += $"<p class=\"text-danger\">{file.FileName} type was not correct</p>";
                            continue;
                        }

                        if (!file.CheckFileSize(FileSize.KB, 100))
                        {
                            text += $"<p class=\"text-danger\">{file.FileName} size was not correct</p>";
                            continue;
                        }

                        product.ProductImages.Add(new ProductImage
                        {
                            Image = await file.CreateFile(
                                _env.WebRootPath,
                                "assets",
                                "images",
                                "website-images"
                            ),
                            IsPrimary = null
                        });
                    }

                    TempData["FileWarning"] = text;
                }

                product.Name = productUpdateVM.Name;
                product.Price = productUpdateVM.Price;
                product.Description = productUpdateVM.Description;
                product.SKU = productUpdateVM.SKU;
                product.CategoryId = productUpdateVM.CategoryId.Value;

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
        }
    }
