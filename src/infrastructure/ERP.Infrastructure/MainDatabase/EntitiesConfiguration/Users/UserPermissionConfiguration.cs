using ERP.Domain.Entities.Users;

namespace ERP.Infrastructure.MainDatabase.EntitiesConfiguration.Users
{
    public class UserPermissionConfiguration : IEntityTypeConfiguration<UserPermission>
    {
        public void Configure(EntityTypeBuilder<UserPermission> builder)
        {
            builder.ToTable("UsersPermissions");

            builder.Property(up => up.Title).HasMaxLength(200).IsRequired();
            builder.Property(up => up.Value).HasMaxLength(200).IsRequired();
        }
    }
}
