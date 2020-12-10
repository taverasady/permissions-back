using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Permissions.DAL.Entities;

namespace Permissions.DAL.EntitiesConfiguration
{
    public class PermitConfiguration : IEntityTypeConfiguration<Permit>
    {
        public void Configure(EntityTypeBuilder<Permit> builder)
        {
            builder.Property(e => e.EmployeeName)
                    .HasMaxLength(150)
                    .IsRequired();

            builder.Property(e => e.EmployeeLastName)
                    .HasMaxLength(150)
                    .IsRequired();

            builder.Property(e => e.PermitDate)
                    .IsRequired();
        }
    }
}
