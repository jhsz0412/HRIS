using HRIS.Domain.Common;

namespace HRIS.Domain.Entities;

public class EmployeeStatus : BaseEntity
{
    public string Code { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private EmployeeStatus()
    {
    }

    public EmployeeStatus(string code, string name)
    {
        Code = code;
        Name = name;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}