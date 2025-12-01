namespace ERP.Domain.Entities.Users
{
    public class UserSession : BaseEntity
    {
        public Guid UserId { get; private set; } = default!;
        public User User { get; private set; } = default!;
        public string Token { get; private set; } = default!;
        public DateTimeOffset TokenExpireDate { get; private set; }
        public string InternetProtocol { get; private set; } = default!;
        public string? DeviceName { get; private set; }
        public string? OperatingSystem { get; private set; }

        private UserSession()
        {
        }

        public UserSession(User user, string token, DateTimeOffset tokenExpireDate, string internetProtocol, string? deviceName = null, string? operatingSystem = null)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            ArgumentException.ThrowIfNullOrWhiteSpace(token, nameof(token));
            ArgumentException.ThrowIfNullOrEmpty(internetProtocol, nameof(internetProtocol));
            User = user;
            UserId = user.Id;
            Token = token;
            TokenExpireDate = tokenExpireDate;
            InternetProtocol = internetProtocol;
            DeviceName = deviceName;
            OperatingSystem = operatingSystem;
        }
    }
}
