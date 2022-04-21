using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinqLab_.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
