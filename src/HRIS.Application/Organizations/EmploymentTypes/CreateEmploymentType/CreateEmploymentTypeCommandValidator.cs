using FluentValidation;

namespace HRIS.Application.Organizations.EmploymentTypes.CreateEmploymentType;

public class CreateEmploymentTypeCommandValidator
    : AbstractValidator<CreateEmploymentTypeCommand>
{
    public CreateEmploymentTypeCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}