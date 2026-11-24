using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public decimal AverageGrade { get; set; }

        public Student(string name, int age, string email, decimal averageGrade)
        {
            Name = name;
            Age = age;
            Email = email;
         
        }

        public Student(string name, int age, string email)
        {
            Name = name;
            Age = age;
            Email = email;
        }

        public void UpdateAverage(decimal value)
        {
            if (value < 1 || value > 10)
            {
                throw new ArgumentOutOfRangeException("Average grade must be between 1 and 10.");
            }
            AverageGrade = value;
        }
        

    }
}
