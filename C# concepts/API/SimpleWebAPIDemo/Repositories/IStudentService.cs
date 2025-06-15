using SimpleWebAPIDemo.Models;

namespace SimpleWebAPIDemo.Repositories
{
    public interface IStudentService
    {
        public List<Student> GetAllStudents();
        public List<Student> GetStudentByName(string name);
        public List<Student> GetStudentByAge(int age);
        public List<Student> GetStudentByGendeerAndCity(string gender, string city);
        public string UpdateStudent(Student student);
        public IEnumerable<Student> SearchStudents(StudentSearch studentSearch);
        public string DeleteStudent(int id);
        public Student GetStudent(int id);
        public int AddStudent(Student student);
    }
}
