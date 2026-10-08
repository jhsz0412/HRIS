using FluentValidation;

namespace HRIS.Application.Employees.CreateEmployee;

public class CreateEmployeeCommandValidator
    : AbstractValidator<CreateEmployeeCommand>
{
    public CreateEmployeeCommandValidator()
    {
        RuleFor(x => x.EmployeeNumber)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.MiddleName)
            .MaximumLength(100);

        RuleFor(x => x.Suffix)
            .MaximumLength(20);

        RuleFor(x => x.BirthDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .When(x => x.BirthDate.HasValue);

        RuleFor(x => x.Gender)
            .MaximumLength(30);

        RuleFor(x => x.Email)
            .EmailAddress()
            .MaximumLength(255)
            .When(x => !string.IsNullOrWhiteSpace(x.Email));

        RuleFor(x => x.MobileNumber)
            .MaximumLength(30);

        RuleFor(x => x.CompanyId)
            .GreaterThan(0);

        RuleFor(x => x.DepartmentId)
            .GreaterThan(0);

        RuleFor(x => x.GroupId)
            .GreaterThan(0)
            .When(x => x.GroupId.HasValue);

        RuleFor(x => x.PositionId)
            .GreaterThan(0);

        RuleFor(x => x.EmploymentTypeId)
            .GreaterThan(0);

        RuleFor(x => x.EmployeeStatusId)
            .GreaterThan(0);

        RuleFor(x => x.DateHired)
            .NotEmpty();
    }
}