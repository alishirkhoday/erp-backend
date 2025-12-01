namespace ERP.Application.UseCases.Modules.HumanResourcesManagement.Commands.CreateNewHuman
{
    public class CreateNewHumanCommandValidator : AbstractValidator<CreateNewHumanCommand>
    {
        public CreateNewHumanCommandValidator()
        {
            RuleFor(h => h.UserId).NotEmpty().WithMessage("");
            RuleFor(h => h.NationalId).NotEmpty().WithMessage("");
            RuleFor(h => h.Name).NotEmpty().WithMessage("");
            RuleFor(h => h.Family).NotEmpty().WithMessage("");
            RuleFor(h => h.Gender).IsInEnum();
        }
    }
}
