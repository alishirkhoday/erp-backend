using ERP.Domain.Entities.Files;
using ERP.Domain.Entities.Modules.CustomersRelationshipManagement;
using ERP.Domain.Entities.Modules.FinanceManagement;
using ERP.Domain.Entities.Modules.HumanResourcesManagement;
using ERP.Domain.Entities.Modules.InventoryManagement;
using ERP.Domain.Entities.Modules.OrderManagement;
using ERP.Domain.Entities.Modules.PlanningManagement;
using ERP.Domain.Entities.Modules.SaleAndMarketingManagement;
using ERP.Domain.Entities.Modules.WarehouseManagement;
using ERP.Domain.Entities.Users;
using ERP.Domain.Primitives;

namespace ERP.Infrastructure.MainDatabase.Context
{
    public class MainDbContext : DbContext, IMainDbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MainDbContext).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType) && entityType.ClrType != typeof(BaseEntity))
                {
                    var builder = modelBuilder.Entity(entityType.ClrType);

                    builder.Property(nameof(BaseEntity.Id))
                           .IsRequired();

                    builder.Property(nameof(BaseEntity.CreationDateTime))
                           .HasColumnType("datetimeoffset(0)")
                           .IsRequired();

                    builder.Property(nameof(BaseEntity.ConcurrencyStamp))
                           .HasMaxLength(100)
                           .IsRequired(false);

                    builder.Property(nameof(BaseEntity.ModifiedBy))
                           .HasMaxLength(100)
                           .IsRequired(false);

                    builder.Property(nameof(BaseEntity.ModificationDateTime))
                           .HasColumnType("datetimeoffset(0)")
                           .IsRequired(false);
                }
            }

            base.OnModelCreating(modelBuilder);
        }

        public async Task<int> SaveChanges(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        public DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<UserProfile> UsersProfiles => Set<UserProfile>();
        public DbSet<UserSession> UsersSessions => Set<UserSession>();
        public DbSet<UserPermission> UserPermissions => Set<UserPermission>();

        public DbSet<Attachment> Attachments => Set<Attachment>();

        public DbSet<Department> Departments => Set<Department>();
        public DbSet<Position> Positions => Set<Position>();
        public DbSet<Human> Humans => Set<Human>();
        public DbSet<HumanContactInformation> HumansContactInformation => Set<HumanContactInformation>();
        public DbSet<HumanBankAccount> HumansBankAccounts => Set<HumanBankAccount>();
        public DbSet<HumanEducation> HumanEducations => Set<HumanEducation>();
        public DbSet<HumanEducationFieldOfStudy> HumanEducationFieldOfStudies => Set<HumanEducationFieldOfStudy>();
        public DbSet<HumanEducationUniversity> HumanEducationUniversities => Set<HumanEducationUniversity>();
        public DbSet<HumanWorkExperience> HumanWorkExperiences => Set<HumanWorkExperience>();
        public DbSet<HumanContract> HumanContracts => Set<HumanContract>();
        public DbSet<HumanAttendanceRecord> HumanAttendanceRecords => Set<HumanAttendanceRecord>();
        public DbSet<HumanLeaveRequest> HumanLeaveRequests => Set<HumanLeaveRequest>();
        public DbSet<HumanPerformanceReview> HumanPerformanceReviews => Set<HumanPerformanceReview>();
        public DbSet<Company> Companies => Set<Company>();
        public DbSet<Job> Jobs => Set<Job>();

        public DbSet<FinancialYear> FinancialYears => Set<FinancialYear>();
        public DbSet<Bank> Banks => Set<Bank>();
        public DbSet<BankBranch> BankBranches => Set<BankBranch>();
        public DbSet<BankBranchAccount> BankBranchAccounts => Set<BankBranchAccount>();
        public DbSet<Account> Accounts => Set<Account>();
        public DbSet<Document> Documents => Set<Document>();
        public DbSet<DocumentItem> DocumentItems => Set<DocumentItem>();
        public DbSet<Payroll> Payrolls => Set<Payroll>();
        public DbSet<Reward> Rewards => Set<Reward>();
        public DbSet<Deduction> Deductions => Set<Deduction>();
        public DbSet<PayrollReward> PayrollRewards => Set<PayrollReward>();
        public DbSet<PayrollDeduction> PayrollDeductions => Set<PayrollDeduction>();
        public DbSet<Tax> Taxes => Set<Tax>();

        public DbSet<Warehouse> Warehouses => Set<Warehouse>();
        public DbSet<WarehouseStorageLocation> WarehouseStorageLocations => Set<WarehouseStorageLocation>();
        public DbSet<WarehouseTransaction> WarehouseTransactions => Set<WarehouseTransaction>();
        public DbSet<WarehouseTransactionItem> WarehouseTransactionItems => Set<WarehouseTransactionItem>();

        public DbSet<ItemGroup> ItemGroups => Set<ItemGroup>();
        public DbSet<ItemAttribute> ItemAttributes => Set<ItemAttribute>();
        public DbSet<ItemAttributeValue> ItemAttributesValues => Set<ItemAttributeValue>();
        public DbSet<Item> Items => Set<Item>();
        public DbSet<ItemSpecification> ItemSpecifications => Set<ItemSpecification>();
        public DbSet<ItemInventory> ItemsInventories => Set<ItemInventory>();
        public DbSet<UnitOfMeasure> UnitOfMeasures => Set<UnitOfMeasure>();
        public DbSet<ItemUnitOfMeasure> ItemUnitOfMeasures => Set<ItemUnitOfMeasure>();
        public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
        public DbSet<PurchaseOrderItem> PurchaseOrderItems => Set<PurchaseOrderItem>();
        public DbSet<SaleOrder> SaleOrders => Set<SaleOrder>();
        public DbSet<SaleOrderItem> SaleOrderItems => Set<SaleOrderItem>();

        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<CustomerAddress> CustomerAddresses => Set<CustomerAddress>();
        public DbSet<Ticket> CustomerTickets => Set<Ticket>();
        public DbSet<TicketSubject> CustomerTicketSubjects => Set<TicketSubject>();
        public DbSet<TicketMessage> CustomerTicketMessages => Set<TicketMessage>();
        public DbSet<Invoice> Invoices => Set<Invoice>();
        public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();

        public DbSet<Meeting> Meetings => Set<Meeting>();
        public DbSet<MeetingAttendee> MeetingAttendees => Set<MeetingAttendee>();

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();
        public DbSet<OrderShipmentStatusHistory> OrderShipmentStatusHistories => Set<OrderShipmentStatusHistory>();
        public DbSet<Payment> Payments => Set<Payment>();
        public DbSet<DiscountCode> DiscountCodes => Set<DiscountCode>();

        public DbSet<Lead> Leads => Set<Lead>();
        public DbSet<LeadInteraction> LeadInteractions => Set<LeadInteraction>();
        public DbSet<LeadNote> LeadNotes => Set<LeadNote>();
        public DbSet<LeadOpportunity> LeadOpportunities => Set<LeadOpportunity>();
    }
}
