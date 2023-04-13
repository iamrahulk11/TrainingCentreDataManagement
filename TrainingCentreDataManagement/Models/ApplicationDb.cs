using Microsoft.EntityFrameworkCore;

namespace TrainingCentreDataManagement.Models
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions options) : base(options) { }

        public DbSet<Login> logins { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Batch> batches { get; set; }
        public DbSet<Student> students { get; set; }

    }
}
