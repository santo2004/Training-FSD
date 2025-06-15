namespace SimpleWebAPIDemo.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public string Duration { get; set; }
        ICollection<Student> Students { get; set; }
    }
}
