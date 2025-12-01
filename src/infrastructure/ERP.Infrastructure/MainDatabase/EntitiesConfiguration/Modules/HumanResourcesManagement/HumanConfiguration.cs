using ERP.Domain.Entities.Modules.HumanResourcesManagement;

namespace ERP.Infrastructure.MainDatabase.EntitiesConfiguration.Modules.HumanResourcesManagement
{
    public class HumanConfiguration : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> builder)
        {
            builder.ToTable("Humans");

            builder.OwnsOne(h => h.NationalId, h =>
            {
                h.WithOwner();
                h.HasIndex(h => h.Value).IsUnique();
                h.Property(h => h.Value).HasMaxLength(50).IsRequired();
            });

            builder.OwnsOne(h => h.PassportId, h =>
            {
                h.WithOwner();
                h.HasIndex(h => h.Value).IsUnique();
                h.Property(h => h.Value).HasMaxLength(50).IsRequired(false);
            });

            builder.OwnsOne(h => h.Address, h =>
            {
                h.WithOwner();
                h.Property(h => h.Latitude).HasMaxLength(50).IsRequired(false);
                h.Property(h => h.Longitude).HasMaxLength(50).IsRequired(false);
                h.Property(h => h.Country).HasMaxLength(50).IsRequired();
                h.Property(h => h.Province).HasMaxLength(50).IsRequired();
                h.Property(h => h.City).HasMaxLength(50).IsRequired();
                h.Property(h => h.Region).HasMaxLength(50).IsRequired();
                h.Property(h => h.Street).HasMaxLength(50).IsRequired();
                h.Property(h => h.Plaque).HasMaxLength(50).IsRequired();
                h.Property(h => h.PostalCode).HasMaxLength(50).IsRequired();
            });

            builder.Property(h => h.Name).HasMaxLength(50).IsRequired();
            builder.Property(h => h.Family).HasMaxLength(100).IsRequired();

            builder.HasOne(h => h.User).WithOne().HasForeignKey<Human>(h => h.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
