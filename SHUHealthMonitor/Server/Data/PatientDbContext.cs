using SHUHealthMonitor.Shared.Models;
using SHUHealthMonitor.Server.Data;
using Microsoft.EntityFrameworkCore;
using SHUHealthMonitor.Server.Models;


//patient dbcontext, used for loading in patient details to be shown to administrator/doctor user roles. This feature is tempermental and sometimes doesn't work.z
namespace SHUHealthMonitor.Server.Data
{

    public partial class PatientDbContext : DbContext
    {
        public PatientDbContext()
        {
        }
        public PatientDbContext(DbContextOptions<PatientDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<PatientModel> patient { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PatientModel>().HasData(DataGenerator.Patients);

        }
    }
}