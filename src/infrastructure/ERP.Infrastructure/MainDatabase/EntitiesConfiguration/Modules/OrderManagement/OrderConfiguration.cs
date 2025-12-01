using ERP.Domain.Entities.Modules.OrderManagement;

namespace ERP.Infrastructure.MainDatabase.EntitiesConfiguration.Modules.OrderManagement
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.OwnsOne(o => o.ShipToAddress, o =>
            {
                o.WithOwner();
                o.Property(o => o.Latitude).HasMaxLength(50).IsRequired(false);
                o.Property(o => o.Longitude).HasMaxLength(50).IsRequired(false);
                o.Property(o => o.Country).HasMaxLength(50).IsRequired();
                o.Property(o => o.Province).HasMaxLength(50).IsRequired();
                o.Property(o => o.City).HasMaxLength(50).IsRequired();
                o.Property(o => o.Region).HasMaxLength(50).IsRequired();
                o.Property(o => o.Street).HasMaxLength(50).IsRequired();
                o.Property(o => o.Plaque).HasMaxLength(50).IsRequired();
                o.Property(o => o.PostalCode).HasMaxLength(50).IsRequired();
                o.Property(o => o.ReceiverFullName).HasMaxLength(150).IsRequired();
                o.Property(o => o.ReceiverMobileNumber).HasMaxLength(50).IsRequired();
            });

            builder.Property(o => o.Code).HasMaxLength(50).IsRequired();
            builder.Property(o => o.RegistrationDateTime).HasColumnType("datetimeoffset(0)").IsRequired();
            builder.Property(o => o.TimeLeftToPayment).HasColumnType("datetimeoffset(0)").IsRequired();
        }
    }
}
