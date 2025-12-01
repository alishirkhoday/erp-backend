using ERP.Domain.Entities.Users.ValueObjects;

namespace ERP.Domain.Entities.Users
{
    public class UserProfile : BaseEntity
    {
        public Guid UserId { get; private set; } = default!;
        public User User { get; private set; } = default!;
        public Image Image { get; private set; } = default!;

        private UserProfile()
        {
        }

        public UserProfile(User user)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            User = user;
            UserId = user.Id;
        }

        public void SetImage(Image image)
        {
            ArgumentNullException.ThrowIfNull(image, nameof(image));
            Image = image;
        }
    }
}
