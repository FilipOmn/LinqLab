using System;
using System.Collections.Generic;
using System.Text;

namespace LinqLab_.Models
{
    public class Class
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public List<Student> Students { get; set; }
    }
}
