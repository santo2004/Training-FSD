using SimpleWebAPIDemo.Models;

namespace SimpleWebAPIDemo.Repositories
{
    public class StudentService : IStudentService
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(){StudentId = 1, StudentEmail = "Ashik@gmail.com", StudentName = "Ashik", Course = "Angular",Age = 22, Gender = "Male", City="Villupuram"},
            new Student(){StudentId = 2, StudentEmail = "Jesro@gmail.com", StudentName = "Jesro", Course = "FSD",Age = 22, Gender = "Male", City="Villupuram"},
            new Student(){StudentId = 3, StudentEmail = "Nitish@gmail.com", StudentName = "Nitish", Course = "Python", Age = 22, Gender = "Male", City = "Villupuram"},
            new Student(){StudentId = 4, StudentEmail = "Lokesh@gmail.com", StudentName = "Lokesh", Course = "C#", Age = 22, Gender = "Male", City = "Villupuram"},
            new Student(){StudentId = 5, StudentEmail = "Shruthi@gmail.com", StudentName = "Shruthi", Course = "React", Age = 22, Gender = "Female", City = "Villupuram"},
            new Student(){StudentId = 6, StudentEmail = "Viji@gmail.com", StudentName = "Viji", Course = "Java", Age = 22, Gender = "Female", City = "Villupuram"},

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

        public List<Student> GetStudentByName(string name)
        {
            var studentList = students.Where(s => s.StudentName.ToLower() == (name.ToLower())).ToList();
            return studentList;
        }

        public List<Student> GetStudentByAge(int age)
        {
            var stud = students.Where(s => s.Age == age).ToList();
            return stud;
        }

        /*public List<Student> GetStudentByGenderAndCity(string gender, string city)
        {
            var filteredStud = students.Where(s => s.Gender.Equals(gender,StringComparison.OrdinalIgnoreCase)&&
            s.City.Equals(city,StringComparison.OrdinalIgnoreCase)).ToList();
            if(!filteredStud.Any())
            {
                return null;
            }
            else
            {
                return filteredStud;
            }
        }*/

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

        List<Student> IStudentService.GetStudentByAge(int age)
        {
            var studentList = students.Where(s => s.Age == age).ToList();
            return studentList;
        }

        public List<Student> GetStudentByGendeerAndCity(string gender, string city)
        {
            var filteredStudents = new List<Student>();

            if (!string.IsNullOrEmpty(gender))
            {
                filteredStudents = students.Where(s => s.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(city))
            {
                filteredStudents = students.Where(s => s.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(gender) && !string.IsNullOrEmpty(city))
            {
                filteredStudents = students.Where(s => s.Gender.Equals(gender, StringComparison.OrdinalIgnoreCase) && s.City.Equals(city, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!filteredStudents.Any())
            {
                return null;
            }
            else
            {
                return filteredStudents;
            }
        }

        public IEnumerable<Student> SearchStudents(StudentSearch studentSearch)
        {
            var filteredStudents = new List<Student>();
            if (!string.IsNullOrEmpty(studentSearch.Name))
            {
                filteredStudents = students.Where(s => s.StudentName.Contains(studentSearch.Name, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(studentSearch.Gender))
            {
                filteredStudents = students.Where(s => s.Gender.Equals(studentSearch.Gender, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(studentSearch.City))
            {
                filteredStudents = students.Where(s => s.City.Contains(studentSearch.City, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!filteredStudents.Any())
            {
                return null;
            }
            else
            {
                return filteredStudents;
            }
        }
    }
}
