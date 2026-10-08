using FluentValidation;

namespace HRIS.Application.Organizations.Groups.CreateGroup;

public class CreateGroupCommandValidator
    : AbstractValidator<CreateGroupCommand>
{
    public CreateGroupCommandValidator()
    {
        RuleFor(x => x.DepartmentId)
            .GreaterThan(0);

        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}