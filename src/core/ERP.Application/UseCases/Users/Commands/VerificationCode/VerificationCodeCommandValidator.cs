namespace ERP.Application.UseCases.Users.Commands.VerificationCode
{
    public sealed class VerificationCodeCommandValidator : AbstractValidator<VerificationCodeCommand>
    {
        public VerificationCodeCommandValidator()
        {
            RuleFor(u => u.Username)
                .NotEmpty().WithMessage(Helpers.ValidatorsMessages.UsernameIsRequired)
                .Must(u => u.IsValidateUsername()).WithMessage(Helpers.ValidatorsMessages.UsernameIsNotValid);

            RuleFor(u => u.MobilePhoneNumberWithRegionCode)
                .MaximumLength(20).WithMessage(Helpers.ValidatorsMessages.MobilePhoneNumberWithRegionCodeLength)
                .When(u => u.MobilePhoneNumberWithRegionCode != null && u.MobilePhoneNumberWithRegionCode.Length > 0);

            RuleFor(u => u.Email)
                .MaximumLength(256).WithMessage(Helpers.ValidatorsMessages.EmailLength)
                .When(u => u.Email != null && u.Email.Length > 0);

            RuleFor(u => u.Code)
                .NotEmpty().WithMessage(Helpers.ValidatorsMessages.VerificationCodeIsRequired);
        }
    }
}
