using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Domain
{
    public class Student
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public string Email { get; private set; }
        public decimal AverageGrade { get; private set; }

        public Student(string name, int age, string email, decimal averageGrade)
        {
            Name = name;
            Age = age;
            Email = email;
            AverageGrade = averageGrade;
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
