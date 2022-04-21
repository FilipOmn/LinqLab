using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LinqLab_.Models
{
    public class CourseStudent
    {
        [Key]
        public int CourseStudentId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
    }
}
