using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepublicOfCocos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepublicOfCocos.Infraestructure.Data.Configurations
{
    class SurgeryConfiguration : IEntityTypeConfiguration<Surgery>
    {
        public void Configure(EntityTypeBuilder<Surgery> builder)
        {
            builder.Property(e => e.SurgeryId)
                    .HasColumnName("SurgeryID")
                    .ValueGeneratedNever();

            builder.Property(e => e.DoctorName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
