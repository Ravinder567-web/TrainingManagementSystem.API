using Microsoft.EntityFrameworkCore;
using TrainingManagementSystem.API.Models;

namespace TrainingManagementSystem.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Enrolment> Enrolments { get; set; }
    }
}
