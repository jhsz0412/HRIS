using HRIS.Domain.Common;

namespace HRIS.Domain.Entities;

public class Group : BaseEntity
{
    public int DepartmentId { get; private set; }

    public string Code { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private Group()
    {
    }

    public Group(int departmentId, string code, string name)
    {
        DepartmentId = departmentId;
        Code = code;
        Name = name;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}