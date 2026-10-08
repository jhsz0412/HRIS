using FluentValidation;

namespace HRIS.Application.Organizations.Departments.CreateDepartment;

public class CreateDepartmentCommandValidator
    : AbstractValidator<CreateDepartmentCommand>
{
    public CreateDepartmentCommandValidator()
    {
        RuleFor(x => x.CompanyId)
            .GreaterThan(0);

        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}