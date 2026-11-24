using Microsoft.EntityFrameworkCore;
using StudentManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Infrastructure
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Enrollment>().ToTable("Enrollments");
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Student>()
                .Property(s => s.Age)
                .HasColumnType("int");

            modelBuilder.Entity<Student>()
                .Property(s => s.AverageGrade)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Course>()
                .Property(c => c.Credits)
                .HasColumnType("int");

            modelBuilder.Entity<Enrollment>()
                .Property(e => e.Grade)
                .HasPrecision(18, 2);
        }
    }
}
