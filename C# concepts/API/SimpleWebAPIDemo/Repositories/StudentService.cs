using SimpleWebAPIDemo.Models;

namespace SimpleWebAPIDemo.Repositories
{
    public class StudentService : IStudentService
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(){StudentId = 1, StudentEmail = "Ashik@gmail.com", StudentName = "Ashik", Course = "Angular"},
            new Student(){StudentId = 2, StudentEmail = "Jesro@gmail.com", StudentName = "Jesro", Course = "FSD"},
            new Student(){StudentId = 3, StudentEmail = "Nitish@gmail.com", StudentName = "Nitish", Course = "Python"},
            new Student(){StudentId = 4, StudentEmail = "Lokesh@gmail.com", StudentName = "Lokesh", Course = "C#"},
            new Student(){StudentId = 5, StudentEmail = "Shruthi@gmail.com", StudentName = "Shruthi", Course = "React"},
            new Student(){StudentId = 6, StudentEmail = "Viji@gmail.com", StudentName = "Viji", Course = "Java"},

        };
        public int AddStudent(Student student)
        {
            if (student != null)
            {
                students.Add(student);
                return student.StudentId;
            }
            else
                return 0;
        }

        public string DeleteStudent(int id)
        {
            var student = students.Where(s => s.StudentId == id).FirstOrDefault();
            if (student != null)
            {
                students.Remove(student);
                return "Student deleted successfully";
            }
            else
            {
                return "Student not found";
            }
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudent(int id)
        {
            var student = students.Where(s => s.StudentId == id).FirstOrDefault();
            if (student == null)
                return null;
            else
                return student;
        }

        public string UpdateStudent(Student student)
        {
            var index = students.FindIndex(s => s.StudentId == student.StudentId);
            if (index != -1)
            {
                students[index] = student;
                return "Student updated successfully";
            }
            else
                return "Student not found";
        }
    }
}
