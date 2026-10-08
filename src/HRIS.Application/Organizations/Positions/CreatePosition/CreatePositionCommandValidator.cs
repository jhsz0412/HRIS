using FluentValidation;

namespace HRIS.Application.Organizations.Positions.CreatePosition;

public class CreatePositionCommandValidator
    : AbstractValidator<CreatePositionCommand>
{
    public CreatePositionCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}