using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ExamAPI.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options):base(options) {
        }

        public DbSet <Project> Projects { get; set; }
        public DbSet <Employees> Employees { get; set; }
        public DbSet <ProjectEmployee> ProjectEmployees { get; set; }

    }
}
