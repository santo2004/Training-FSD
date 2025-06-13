using Microsoft.AspNetCore.Mvc;
using MVC_demo.Models;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace MVC_demo.Controllers
{
    public class DepartmentsController : Controller
    {
       
        public static List<Department>  dept_List = new List<Department> {
                new Department() { Id = 102 , Name = "rehan" , Location = "Mumbai"  },
                new Department() { Id = 103 , Name = "Pari" , Location = "Pune"},
                new Department() { Id = 104 , Name = "Harini" , Location = "Chennai"},
                new Department() { Id = 105 , Name = "Gokul" , Location = "Pune"}

    };
    public IActionResult Index()
        {
            //Department dept = new Department();
             
            //dept.Id = 101;
            //dept.Name = "CSE";
            //dept.Location = "Nagpur";

        


            //ViewData["Name"] = "Alhan";
            //ViewData["Domain"] = ".netFullStack";
            //ViewBag.CompanyName = "Hexaware";

            return View(dept_List);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {   
            dept_List.Add(department);

            return RedirectToAction("Index");
            
        }
        public IActionResult Details(int id)
        {
            var departmentDetails = dept_List.FirstOrDefault(d=>d.Id==id);
            return PartialView("_DepartmentDetails",departmentDetails);

        }
    }
}
