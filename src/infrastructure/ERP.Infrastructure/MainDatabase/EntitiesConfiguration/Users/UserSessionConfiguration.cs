using ERP.Domain.Entities.Users;

namespace ERP.Infrastructure.MainDatabase.EntitiesConfiguration.Users
{
    public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder.ToTable("UsersSessions");

            builder.Property(us => us.Token).HasMaxLength(2000).IsRequired();
            builder.Property(us => us.TokenExpireDate).HasColumnType("datetimeoffset(0)").IsRequired();
            builder.Property(us => us.InternetProtocol).HasMaxLength(50).IsRequired();
            builder.Property(us => us.DeviceName).HasMaxLength(200).IsRequired();
            builder.Property(us => us.OperatingSystem).HasMaxLength(100).IsRequired();
        }
    }
}
