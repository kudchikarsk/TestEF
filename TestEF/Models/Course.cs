using System.Collections.Generic;

namespace TestEF.Models
{
    public class Course
    {
        public Course()
        {
            Students = new HashSet<Student>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}