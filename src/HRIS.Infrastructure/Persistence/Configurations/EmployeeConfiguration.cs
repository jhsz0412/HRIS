using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRIS.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable("Employees");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.EmployeeNumber)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasIndex(x => x.EmployeeNumber)
            .IsUnique();

        builder.Property(x => x.FirstName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.MiddleName)
            .HasMaxLength(100);

        builder.Property(x => x.Suffix)
            .HasMaxLength(20);

        builder.Property(x => x.Gender)
            .HasMaxLength(30);

        builder.Property(x => x.Email)
            .HasMaxLength(255);

        builder.Property(x => x.MobileNumber)
            .HasMaxLength(30);

        builder.Property(x => x.DateHired)
            .IsRequired();

        builder.HasOne<Company>()
            .WithMany()
            .HasForeignKey(x => x.CompanyId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Department>()
            .WithMany()
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Group>()
            .WithMany()
            .HasForeignKey(x => x.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<Position>()
            .WithMany()
            .HasForeignKey(x => x.PositionId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<EmploymentType>()
            .WithMany()
            .HasForeignKey(x => x.EmploymentTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne<EmployeeStatus>()
            .WithMany()
            .HasForeignKey(x => x.EmployeeStatusId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}