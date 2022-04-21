using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinqLab_.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public List<Course> Courses { get; set; }
    }
}
