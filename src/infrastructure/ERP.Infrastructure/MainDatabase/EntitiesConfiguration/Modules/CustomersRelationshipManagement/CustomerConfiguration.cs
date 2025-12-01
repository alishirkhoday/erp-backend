using ERP.Domain.Entities.Modules.CustomersRelationshipManagement;

namespace ERP.Infrastructure.MainDatabase.EntitiesConfiguration.Modules.CustomersRelationshipManagement
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(h => h.Name).HasMaxLength(50).IsRequired();
            builder.Property(h => h.Family).HasMaxLength(100).IsRequired(false);

            builder.HasOne(c => c.User).WithOne().HasForeignKey<Customer>(c => c.UserId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
