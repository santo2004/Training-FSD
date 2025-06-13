using Microsoft.AspNetCore.Mvc;
using MVC_Demo.Models;

namespace MVC_Demo.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            Department dept = new Department();
            dept.Id = 101;
            dept.Name = "Santo";
            dept.Location = "Chennai";

            ViewData["Name"] = "Santo";
            ViewBag.Company = "Hexaware";


            return View(dept);
        }
    }
}
