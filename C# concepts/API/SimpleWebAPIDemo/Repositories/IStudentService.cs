using SimpleWebAPIDemo.Models;

namespace SimpleWebAPIDemo.Repositories
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();
        public string UpdateStudent(Student student);
        public string DeleteStudent(int id);
        public Student GetStudent(int id);
        public int AddStudent(Student student);
    }
}
