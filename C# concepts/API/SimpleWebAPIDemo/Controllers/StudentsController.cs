using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleWebAPIDemo.Models;
using SimpleWebAPIDemo.Repositories;
using System.Net;

namespace SimpleWebAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }


        [HttpGet("GetAllStudents")]
        public List<Student> GetStudents()
        {
            try
            {
                return _studentService.GetAllStudents();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetStudentsByID/{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var student = _studentService.GetStudent(id);
                if (student == null)
                {
                    return NotFound();
                }
                return Ok(student);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetStudentsByAge/{age:range(1,60)}")]
        public List<Student> GetStudent(int age)
        {
            try
            {
                return _studentService.GetStudentByAge(age);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("GetStudentsByName/{name}")]
        public List<Student> GetStudentByName(string name)
        {
            try
            {
                return _studentService.GetStudentByName(name);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //[HttpGet("Gender/{gender}/City/{city}")]
        [HttpGet("SearchStudentByGenderCity")]
        public IActionResult GetStudentByGenderAndCity([FromQuery] string? gender, string city)
        {
            try
            {
                var stud = _studentService.GetStudentByGendeerAndCity(gender, city);
                if (stud == null)
                {
                    return NotFound($"no students found with {GetStudentByGenderAndCity} in city {GetStudentByGenderAndCity}");
                }
                else
                {
                    return Ok(stud);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("AddStudents")]
        public IActionResult NewStudent(Student student)
        {
            var id = _studentService.AddStudent(student);
            if (id == 0)
            {
                return BadRequest();
            }
            return Ok($"Studendt with {id} added successfully");
        }

        [HttpPut("Update/{id}")]
        public IActionResult Put(Student student)
        {
            var result = _studentService.UpdateStudent(student);
            return Ok(result);
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _studentService.DeleteStudent(id);
            return Ok(result);
        }

        [HttpPost("SearchStudents")]
        public IActionResult SearchStudents([FromQuery] StudentSearch studentSearch)
        {
            var result = _studentService.SearchStudents(studentSearch);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
