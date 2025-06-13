using DepartmentAPI.Models;

namespace DepartmentAPI.Repositories
{
    public class DepartmentService : IDepartmentService
    {
        private readonly List<Department> _departments = new()
        {
            new Department { Id = 1, DepartmentName = "CSE", DepartmentCode = "CS01", HODName = "Dr. Smith" },
            new Department { Id = 2, DepartmentName = "IT", DepartmentCode = "IT01", HODName = "Dr. Jane" }
        };

        public List<Department> GetAllDepartments() => _departments;

        public Department GetDepartmentById(int id)
        {
            return _departments.FirstOrDefault(d => d.Id == id);
        }

        public int SearchDepartmentById(int id)
        {
            return _departments.Any(d => d.Id == id) ? 1 : 0;
        }

        public int UpdateDepartment(int id, Department dept)
        {
            var existing = _departments.FirstOrDefault(d => d.Id == id);
            if (existing == null) return 0;

            existing.DepartmentName = dept.DepartmentName;
            existing.DepartmentCode = dept.DepartmentCode;
            existing.HODName = dept.HODName;
            return 1;
        }

        public int DeleteDepartment(int id)
        {
            var dept = _departments.FirstOrDefault(d => d.Id == id);
            if (dept == null) return 0;

            _departments.Remove(dept);
            return 1;
        }
    }
}
