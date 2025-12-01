namespace ERP.Application.Services.OTPCodes.Models
{
    public class OTPCode
    {
        public string UserId { get; private set; } = default!;
        public string Code { get; private set; } = default!;
        public DateTimeOffset ExpireDate { get; private set; }
        public OTPCodeChannel Channel { get; private set; }

        public OTPCode()
        {
        }

        public OTPCode(string userId, string code, OTPCodeChannel channel)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            UserId = userId;
            Code = code;
            ExpireDate = DateTimeOffset.UtcNow.AddMinutes(2);
            Channel = channel;
        }
    }
}
