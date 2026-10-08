using HRIS.Domain.Common;

namespace HRIS.Domain.Entities;

public class Employee : BaseEntity
{
    public string EmployeeNumber { get; private set; } = null!;

    public string FirstName { get; private set; } = null!;

    public string LastName { get; private set; } = null!;

    public string? MiddleName { get; private set; }

    public string? Suffix { get; private set; }

    public DateOnly? BirthDate { get; private set; }

    public string? Gender { get; private set; }

    public string? Email { get; private set; }

    public string? MobileNumber { get; private set; }

    public int CompanyId { get; private set; }

    public int DepartmentId { get; private set; }

    public int? GroupId { get; private set; }

    public int PositionId { get; private set; }

    public int EmploymentTypeId { get; private set; }

    public int EmployeeStatusId { get; private set; }

    public DateOnly DateHired { get; private set; }

    private Employee()
    {
    }

    public Employee(
        string employeeNumber,
        string firstName,
        string lastName,
        string? middleName,
        string? suffix,
        DateOnly? birthDate,
        string? gender,
        string? email,
        string? mobileNumber,
        int companyId,
        int departmentId,
        int? groupId,
        int positionId,
        int employmentTypeId,
        int employeeStatusId,
        DateOnly dateHired)
    {
        EmployeeNumber = employeeNumber;
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        Suffix = suffix;
        BirthDate = birthDate;
        Gender = gender;
        Email = email;
        MobileNumber = mobileNumber;

        CompanyId = companyId;
        DepartmentId = departmentId;
        GroupId = groupId;
        PositionId = positionId;
        EmploymentTypeId = employmentTypeId;
        EmployeeStatusId = employeeStatusId;

        DateHired = dateHired;

        CreatedAt = DateTime.UtcNow;
    }
}