using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Infrastructure
{
    public class SchoolDbContextFactory
  : IDesignTimeDbContextFactory<SchoolDbContext>
    {
        public SchoolDbContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<SchoolDbContext>()
                .UseSqlServer(
                    @"Server=localhost;Database=StudentManagementDb;Trusted_Connection=True;TrustServerCertificate=True;")
                .Options;
            return new SchoolDbContext(options);
        }
    }
}
