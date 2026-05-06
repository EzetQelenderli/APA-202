using _26_DynamicPropertiesViewModell.Models;
using _26_DynamicPropertiesViewModell.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _26_DynamicPropertiesViewModell.Controllers
{
    public class HomeController:Controller
    {
        List<Student> _students = new List<Student>()
        {
            new Student{Id=1,Name="Nezrin",Surname="Eliyeva"},
            new Student{Id=1,Name="Nihad",Surname="Eliyev"},
            new Student{Id=1,Name="Mikail",Surname="Abbasov"},
        };
        List<Teacher> _teacher = new List<Teacher>()
        {
            new Teacher{Id=1,Name="Ali",Salary=2400},
            new Teacher{Id=1,Name="Huseyn",Salary=3000}

        };

        public IActionResult Index()
        {
            //ViewBag.Students = _students;
            //ViewData["Students"]=_students;
            //TempData["Name"] = "Elmir";

            HomeVM homeVM = new()
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


        [Route("Korporativ-satislar")]
        public IActionResult CorporativeSales()
        {
            return View();
        }
    }
}
