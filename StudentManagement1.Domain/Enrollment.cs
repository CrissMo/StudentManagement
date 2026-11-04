using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Domain
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }
        public decimal Grade { get; set; }
        // potential cast site

        public Student Student { get; set; } = null;
        public Course Course { get; set; } = null;
    }
}
