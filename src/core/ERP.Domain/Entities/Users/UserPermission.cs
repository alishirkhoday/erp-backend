namespace ERP.Domain.Entities.Users
{
    public class UserPermission : BaseEntity
    {
        public Guid UserId { get; private set; } = default!;
        public User User { get; private set; } = default!;
        public string Title { get; private set; } = default!;
        public string Value { get; private set; } = default!;

        private UserPermission()
        {
        }

        public UserPermission(User user, string title, string value)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            ArgumentException.ThrowIfNullOrWhiteSpace(title, nameof(title));
            ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
            User = user;
            UserId = user.Id;
            Title = title;
            Value = value;
        }
    }
}
