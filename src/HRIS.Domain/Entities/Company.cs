using HRIS.Domain.Common;

namespace HRIS.Domain.Entities;

public class Company : BaseEntity
{
    public string Code { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private Company()
    {
    }

    public Company(string code, string name)
    {
        Code = code;
        Name = name;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}