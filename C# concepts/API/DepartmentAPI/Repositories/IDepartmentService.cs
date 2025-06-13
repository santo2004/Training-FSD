using DepartmentAPI.Models;

namespace DepartmentAPI.Repositories
{
    public interface IDepartmentService
    {
        List<Department> GetAllDepartments();
        Department GetDepartmentById(int id);
        int SearchDepartmentById(int id);
        int UpdateDepartment(int id, Department dept);
        int DeleteDepartment(int id);
    }
}
