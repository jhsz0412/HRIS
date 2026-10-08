using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRIS.Infrastructure.Persistence.Configurations;

public class EmployeeStatusConfiguration : IEntityTypeConfiguration<EmployeeStatus>
{
    public void Configure(EntityTypeBuilder<EmployeeStatus> builder)
    {
        builder.ToTable("EmployeeStatuses");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Code)
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(x => x.Code)
            .IsUnique();
    }
}