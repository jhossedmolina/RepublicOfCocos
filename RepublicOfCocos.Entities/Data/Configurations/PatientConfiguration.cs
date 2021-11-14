using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicOfCocos.Core.Entities;

namespace RepublicOfCocos.Infraestructure.Data.Configurations
{
    class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder.Property(e => e.PatientId)
                   .HasColumnName("PatientID")
                   .ValueGeneratedNever();

            builder.Property(e => e.Gender)
                .IsRequired()
                .HasMaxLength(10)
                .IsFixedLength();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            builder.Property(e => e.Symptom)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            builder.Property(e => e.Triage)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
