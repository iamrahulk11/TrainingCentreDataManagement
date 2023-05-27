using Microsoft.EntityFrameworkCore;

namespace TrainingCentreDataManagement.Models
{
    public class ApplicationDb : DbContext
    {
        public ApplicationDb(DbContextOptions options) : base(options) { }
       
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Batch> batches { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<LoginModel> users { get; set; }

    }
}
