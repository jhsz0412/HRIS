using HRIS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HRIS.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Employee> Employees { get; }
    DbSet<Company> Companies { get; }
    DbSet<Department> Departments { get; }
    DbSet<Group> Groups { get; }
    DbSet<Position> Positions { get; }
    DbSet<EmploymentType> EmploymentTypes { get; }
    DbSet<EmployeeStatus> EmployeeStatuses { get; }

    Task<int> SaveChangesAsync(
        CancellationToken cancellationToken = default);
}