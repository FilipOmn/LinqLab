using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinqLab_.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public virtual ICollection<CourseStudent> CourseStudents { get; set; }
    }
}
