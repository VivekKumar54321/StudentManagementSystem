using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Database
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {

        }
        public DbSet<StudentManagementSystem.Models.Billing> Billing { get; set; }
        public DbSet<StudentManagementSystem.Models.Student> Student { get; set; }
        public DbSet<StudentManagementSystem.Models.Registration> Registration { get; set; }
        public DbSet<StudentManagementSystem.Models.Faculty> Faculty { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
