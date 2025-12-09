namespace ERP.Application.UseCases.UsersManagement.Authentication.SendVerificationCode
{
    public sealed class SendVerificationCodeCommandValidator : AbstractValidator<SendVerificationCodeCommand>
    {
        public SendVerificationCodeCommandValidator()
        {
            RuleFor(u => u.UserId)
                .NotEmpty().WithMessage(Helpers.ValidatorsMessages.UserIdIsRequired);

            RuleFor(u => u.MobilePhoneNumberWithRegionCode)
                .MaximumLength(20).WithMessage(Helpers.ValidatorsMessages.MobilePhoneNumberWithRegionCodeLength)
                .When(u => u.MobilePhoneNumberWithRegionCode != null && u.MobilePhoneNumberWithRegionCode.Length > 0);

            RuleFor(u => u.Email)
                .MaximumLength(256).WithMessage(Helpers.ValidatorsMessages.EmailLength)
                .When(u => u.Email != null && u.Email.Length > 0);
        }
    }
}
