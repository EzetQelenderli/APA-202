using _27_FrontToBackSqlConnectionn.Data;
using _27_FrontToBackSqlConnectionn.Models;
using _27_FrontToBackSqlConnectionn.Utilities.Enums;
using _27_FrontToBackSqlConnectionn.Utilities.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace _27_FrontToBackSqlConnectionn.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]

    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context,IWebHostEnvironment env)
        {
           _context = context;
            _env = env;
        }
        public  async Task<IActionResult> Index()
        {
            List<Slider> sliders = await _context.Sliders.Where(s => !s.IsDeleted).ToListAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        //public IActionResult Test()
        //{
        //    return Content(Guid.NewGuid().ToString());
        //}
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //!slider.Photo.ContentType.Contains("image/")
            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(slider.Photo), "File type is incorrect");
                return View();
            }
            //slider.Photo.Length > 2 * 1024 * 1024
            if (!slider.Photo.CheckFileSize(FileSize.MB,2))
            {
                ModelState.AddModelError(nameof(slider.Photo), "File size must be less then 2 Mb");
                return View();

            }
            slider.Image = await slider.Photo.CreateFile(_env.WebRootPath,"assets","images","website-image");
            await _context.Sliders.AddAsync(slider);


            await _context.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
