namespace ERP.Domain.Entities.Users
{
    public class OneTimePassword
    {
        public string UserId { get; set; } = default!;
        public string Code { get; set; } = default!;
        public DateTimeOffset ExpireDate { get; set; }
        public OneTimePasswordChannel Channel { get; set; }

        public OneTimePassword()
        {
        }

        public OneTimePassword(string userId, string code, DateTimeOffset expireDate, OneTimePasswordChannel channel)
        {
            ArgumentException.ThrowIfNullOrEmpty(userId, nameof(userId));
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            UserId = userId;
            Code = code;
            ExpireDate = expireDate;
            Channel = channel;
        }
    }
}
