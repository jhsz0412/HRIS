using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRIS.Infrastructure.Persistence.Configurations;

public class EmploymentTypeConfiguration : IEntityTypeConfiguration<EmploymentType>
{
    public void Configure(EntityTypeBuilder<EmploymentType> builder)
    {
        builder.ToTable("EmploymentTypes");

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