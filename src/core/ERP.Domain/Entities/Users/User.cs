using ERP.Domain.Entities.Users.ValueObjects;
using System.Text;

namespace ERP.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public Username Username { get; private set; } = default!;
        public string NormalizedUsername { get; private set; } = default!;
        public Password Password { get; private set; } = default!;

        public MobilePhoneNumberRegionCode MobilePhoneNumberRegionCode { get; private set; } = default!;
        public MobilePhoneNumber MobilePhoneNumber { get; private set; } = default!;
        public string? NormalizedMobilePhoneNumber { get; private set; }
        public bool MobilePhoneNumberConfirmed { get; private set; }

        public Email Email { get; private set; } = default!;
        public string? NormalizedEmail { get; private set; }
        public bool EmailConfirmed { get; private set; }

        public UserStatus Status { get; private set; }
        public string SecurityStamp { get; private set; } = default!;

        public int AccessFailedCount { get; private set; }
        public bool LockoutEnabled { get; private set; }
        public DateTimeOffset? LockoutEnd { get; private set; }

        public bool TwoFactorAuthenticationEnabled { get; private set; }

        public UserProfile Profile { get; private set; } = default!;

        private readonly List<UserSession> _sessions = [];
        public IReadOnlyList<UserSession> Sessions => _sessions;

        private readonly List<UserPermission> _permissions = [];
        public IReadOnlyList<UserPermission> Permissions => _permissions;

        private User()
        {
        }

        public User(string username, string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username, nameof(username));
            ArgumentException.ThrowIfNullOrWhiteSpace(password, nameof(password));
            Username = username;
            NormalizedUsername = Username.Value.ToLowerInvariant();
            Password = password;
            Status = UserStatus.Inactive;
            LockoutEnabled = true;
            SetSecurityStamp();
        }

        public void ChangeUsername(string username)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(username, nameof(username));
            Username = username;
            NormalizedUsername = Username.Value.ToLowerInvariant();
        }

        public void ChangePassword(string password)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(password, nameof(password));
            Password = password;
            AccessFailedCount = 0;
            LockoutEnd = null;
            SetSecurityStamp();
        }

        public void SetMobilePhoneNumber(string mobilePhoneNumberRegionCode, string mobilePhoneNumber)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(mobilePhoneNumberRegionCode, nameof(mobilePhoneNumberRegionCode));
            ArgumentException.ThrowIfNullOrWhiteSpace(mobilePhoneNumber, nameof(mobilePhoneNumber));
            MobilePhoneNumberRegionCode = mobilePhoneNumberRegionCode;
            MobilePhoneNumber = mobilePhoneNumber;
            NormalizedMobilePhoneNumber = new StringBuilder(MobilePhoneNumberRegionCode.Value).Append(MobilePhoneNumber.Value).ToString();
            MobilePhoneNumberConfirmed = false;
        }

        public void SetEmail(string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(email, nameof(email));
            Email = email;
            NormalizedEmail = Email.Value.ToLowerInvariant();
            EmailConfirmed = false;
        }

        public void ConfirmMobilePhoneNumber() => MobilePhoneNumberConfirmed = true;
        public void ConfirmEmail() => EmailConfirmed = true;

        public void Active()
        {
            Status = UserStatus.Active;
        }

        public void HandleAccessFailed()
        {
            AccessFailedCount++;
            if (AccessFailedCount >= 3 && AccessFailedCount <= 5)
            {
                LockoutEnd = DateTimeOffset.UtcNow.AddMinutes(15);
            }
            if (AccessFailedCount > 5)
            {
                LockoutEnd = DateTimeOffset.UtcNow.AddHours(12);
            }
            if (AccessFailedCount > 10)
            {
                Status = UserStatus.Ban;
            }
        }

        public void ResetLockout()
        {
            AccessFailedCount = 0;
            LockoutEnd = null;
        }

        public void Ban()
        {
            Status = UserStatus.Ban;
            AccessFailedCount = 0;
            LockoutEnd = null;
            SetSecurityStamp();
        }

        public void Enable2FA() => TwoFactorAuthenticationEnabled = true;
        public void Disable2FA() => TwoFactorAuthenticationEnabled = false;

        public void ForceLogoutAllSessions()
        {
            AccessFailedCount = 0;
            LockoutEnd = null;
            SetSecurityStamp();
        }

        private void SetSecurityStamp() => SecurityStamp = Guid.NewGuid().ToString("N");

        public void SetProfile(UserProfile profile)
        {
            ArgumentNullException.ThrowIfNull(profile, nameof(profile));
            Profile = profile;
        }

        public void AddSession(UserSession session)
        {
            ArgumentNullException.ThrowIfNull(session, nameof(session));
            _sessions.Add(session);
        }

        public void AddPermission(UserPermission permission)
        {
            ArgumentNullException.ThrowIfNull(permission, nameof(permission));
            _permissions.Add(permission);
        }
    }
}
