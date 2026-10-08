using FluentValidation;

namespace HRIS.Application.Organizations.Companies.CreateCompany;

public class CreateCompanyCommandValidator
    : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(200);
    }
}