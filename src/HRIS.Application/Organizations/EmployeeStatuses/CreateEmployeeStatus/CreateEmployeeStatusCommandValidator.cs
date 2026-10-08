using FluentValidation;

namespace HRIS.Application.Organizations.EmployeeStatuses.CreateEmployeeStatus;

public class CreateEmployeeStatusCommandValidator
    : AbstractValidator<CreateEmployeeStatusCommand>
{
    public CreateEmployeeStatusCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}