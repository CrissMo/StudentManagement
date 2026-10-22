using System;
using System.Collections.Generic;
using System.Text;



namespace StudentManagement.Domain
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public Course(string name, int credits)
        {
            Name = name;
            Credits = credits;
        }
    }
}
