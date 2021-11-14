using Microsoft.EntityFrameworkCore;
using RepublicOfCocos.Core.Entities;
using RepublicOfCocos.Infraestructure.Data.Configurations;

namespace RepublicOfCocos.Infraestructure.Data
{
    public partial class RepublicOfCocosDBContext : DbContext
    {
        public RepublicOfCocosDBContext()
        {
        }

        public RepublicOfCocosDBContext(DbContextOptions<RepublicOfCocosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Patient> Patient { get; set; }
        public virtual DbSet<Surgery> Surgery { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PatientConfiguration());

            modelBuilder.ApplyConfiguration(new SurgeryConfiguration());       

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
