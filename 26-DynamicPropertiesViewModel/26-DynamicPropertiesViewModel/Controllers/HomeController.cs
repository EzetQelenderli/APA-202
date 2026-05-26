using _26_DynamicPropertiesViewModel.Models;
using _26_DynamicPropertiesViewModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _26_DynamicPropertiesViewModel.Controllers
{
    public class HomeController : Controller
    {
        List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Name = "Nihad",Surname ="Aslanov" },
            new Student { Id = 1, Name = "Fuad",Surname ="Movsumov" },
            new Student { Id = 1, Name = "Medet",Surname ="Eliyev" }
        };

        List<Teacher> _teacher = new List<Teacher>
        {
            new Teacher { Id = 1, Name = "Ali",Salary = 2500 },
            new Teacher { Id = 2, Name = "Ehmed",Salary = 3000 }
        };

        public IActionResult Index()
        {
            //ViewBag.Students = _students;
            //ViewData["Students"] = _students;
            //TempData["Nmae"] = "Elmir";

            HomeVM homeVM = new HomeVM()
            {
                Teachers = _teacher,
                Students = _students
            };

            return View(homeVM);
        }
        public IActionResult Detail()
        {
            return View();
        }

        [Route("korporative-satislar")]
        public IActionResult CorporativeSales()
        {
            return View();
        }
    }
}