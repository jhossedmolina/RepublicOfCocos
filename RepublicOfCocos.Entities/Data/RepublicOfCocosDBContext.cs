using Microsoft.EntityFrameworkCore;
using RepublicOfCocos.Core.Entities;
using System.Reflection;

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

        public virtual DbSet<Security> Security { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
