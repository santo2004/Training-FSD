using Microsoft.AspNetCore.Mvc;
using DepartmentAPI.Models;
using DepartmentAPI.Repositories;

namespace DepartmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public ActionResult<List<Department>> GetAll()
        {
            return _departmentService.GetAllDepartments();
        }

        [HttpGet("{id}")]
        public ActionResult<Department> GetById(int id)
        {
            var dept = _departmentService.GetDepartmentById(id);
            if (dept == null) return NotFound("Department not found");
            return dept;
        }

        [HttpGet("search/{id}")]
        public IActionResult Search(int id)
        {
            int result = _departmentService.SearchDepartmentById(id);
            if (result == 0) return NotFound("Department not found");
            return Ok("Department exists");
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Department dept)
        {
            int result = _departmentService.UpdateDepartment(id, dept);
            if (result == 0) return NotFound("Update failed: Department not found");
            return Ok("Department updated successfully");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            int result = _departmentService.DeleteDepartment(id);
            if (result == 0) return NotFound("Delete failed: Department not found");
            return Ok("Department deleted successfully");
        }
    }
}
