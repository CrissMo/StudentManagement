using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Domain
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolleddAt { get; set; }
        public decimal Grade { get; set; }
    }
}
