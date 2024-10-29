
namespace WebApplication1.Models
{
 

    public class Student
    {
        public int id { get; set; }
        public string studentName { get; set; }
        public string stuentGender { get; set; }
        public int age { get; set; }
        public string standard { get; set; }
        public string fatherName { get; set; }
        public string address { get; set; }

        public static implicit operator Student(string v)
        {
            throw new NotImplementedException();
        }
    }

}
