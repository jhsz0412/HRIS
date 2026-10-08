//namespace HRIS.Domain.Entities;

//public class Department
//{
//    public int Id { get; private set; }

//    public int CompanyId { get; private set; }

//    public string Code { get; private set; } = null!;

//    public string Name { get; private set; } = null!;

//    public bool IsActive { get; private set; }

//    private Department()
//    {
//    }

//    public Department(
//        int companyId,
//        string code,
//        string name)
//    {
//        CompanyId = companyId;
//        Code = code;
//        Name = name;
//        IsActive = true;
//    }
//}

using HRIS.Domain.Common;

namespace HRIS.Domain.Entities;

public class Department : BaseEntity
{
    public int CompanyId { get; private set; }

    public string Code { get; private set; } = null!;

    public string Name { get; private set; } = null!;

    public bool IsActive { get; private set; }

    private Department()
    {
    }

    public Department(int companyId, string code, string name)
    {
        CompanyId = companyId;
        Code = code;
        Name = name;
        IsActive = true;
        CreatedAt = DateTime.UtcNow;
    }
}