using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleWebAPIDemo.Models
{
    //[Table("tblStudent")]
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentEmail { get; set; }
        public string Course { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
    }
}
