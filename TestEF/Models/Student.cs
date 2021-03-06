﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEF.Models
{
    public class Student
    {
        public Student()
        {
            Courses = new HashSet<Course>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
