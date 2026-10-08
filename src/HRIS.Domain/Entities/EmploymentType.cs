using HRIS.Domain.Common;

namespace HRIS.Domain.Entities;

public class EmploymentType : BaseEntity
{
    public string Code { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private EmploymentType()
    {
    }

    public EmploymentType(string code, string name)
    {
        Code = code;
        Name = name;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}