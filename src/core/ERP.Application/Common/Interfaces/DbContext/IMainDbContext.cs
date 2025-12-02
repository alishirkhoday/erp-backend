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
using Microsoft.EntityFrameworkCore;

namespace ERP.Application.Common.Interfaces.DbContext
{
    public interface IMainDbContext
    {
        Task<int> SaveChanges(CancellationToken cancellationToken = default);
        DbSet<TEntity> SetEntity<TEntity>() where TEntity : BaseEntity;

        DbSet<User> Users { get; }
        DbSet<UserProfile> UsersProfiles { get; }
        DbSet<UserSession> UsersSessions { get; }
        DbSet<UserPermission> UserPermissions { get; }

        DbSet<Attachment> Attachments { get; }

        DbSet<Department> Departments { get; }
        DbSet<Position> Positions { get; }
        DbSet<Human> Humans { get; }
        DbSet<HumanContactInformation> HumansContactInformation { get; }
        DbSet<HumanBankAccount> HumansBankAccounts { get; }
        DbSet<HumanEducation> HumanEducations { get; }
        DbSet<HumanEducationFieldOfStudy> HumanEducationFieldOfStudies { get; }
        DbSet<HumanEducationUniversity> HumanEducationUniversities { get; }
        DbSet<HumanWorkExperience> HumanWorkExperiences { get; }
        DbSet<HumanContract> HumanContracts { get; }
        DbSet<HumanAttendanceRecord> HumanAttendanceRecords { get; }
        DbSet<HumanLeaveRequest> HumanLeaveRequests { get; }
        DbSet<HumanPerformanceReview> HumanPerformanceReviews { get; }
        DbSet<Company> Companies { get; }
        DbSet<Job> Jobs { get; }

        DbSet<FinancialYear> FinancialYears { get; }
        DbSet<Bank> Banks { get; }
        DbSet<BankBranch> BankBranches { get; }
        DbSet<BankBranchAccount> BankBranchAccounts { get; }
        DbSet<Account> Accounts { get; }
        DbSet<Document> Documents { get; }
        DbSet<DocumentItem> DocumentItems { get; }
        DbSet<Payroll> Payrolls { get; }
        DbSet<Reward> Rewards { get; }
        DbSet<Deduction> Deductions { get; }
        DbSet<PayrollReward> PayrollRewards { get; }
        DbSet<PayrollDeduction> PayrollDeductions { get; }
        DbSet<Tax> Taxes { get; }

        DbSet<Warehouse> Warehouses { get; }
        DbSet<WarehouseStorageLocation> WarehouseStorageLocations { get; }
        DbSet<WarehouseTransaction> WarehouseTransactions { get; }
        DbSet<WarehouseTransactionItem> WarehouseTransactionItems { get; }

        DbSet<ItemGroup> ItemGroups { get; }
        DbSet<ItemAttribute> ItemAttributes { get; }
        DbSet<ItemAttributeValue> ItemAttributesValues { get; }
        DbSet<Item> Items { get; }
        DbSet<ItemSpecification> ItemSpecifications { get; }
        DbSet<ItemInventory> ItemsInventories { get; }
        DbSet<UnitOfMeasure> UnitOfMeasures { get; }
        DbSet<ItemUnitOfMeasure> ItemUnitOfMeasures { get; }
        DbSet<PurchaseOrder> PurchaseOrders { get; }
        DbSet<PurchaseOrderItem> PurchaseOrderItems { get; }
        DbSet<SaleOrder> SaleOrders { get; }
        DbSet<SaleOrderItem> SaleOrderItems { get; }

        DbSet<Customer> Customers { get; }
        DbSet<CustomerAddress> CustomerAddresses { get; }
        DbSet<Ticket> CustomerTickets { get; }
        DbSet<TicketSubject> CustomerTicketSubjects { get; }
        DbSet<TicketMessage> CustomerTicketMessages { get; }
        DbSet<Invoice> Invoices { get; }
        DbSet<InvoiceItem> InvoiceItems { get; }

        DbSet<Meeting> Meetings { get; }
        DbSet<MeetingAttendee> MeetingAttendees { get; }

        DbSet<Order> Orders { get; }
        DbSet<OrderItem> OrderItems { get; }
        DbSet<OrderShipmentStatusHistory> OrderShipmentStatusHistories { get; }
        DbSet<Payment> Payments { get; }
        DbSet<DiscountCode> DiscountCodes { get; }

        DbSet<Lead> Leads { get; }
        DbSet<LeadInteraction> LeadInteractions { get; }
        DbSet<LeadNote> LeadNotes { get; }
        DbSet<LeadOpportunity> LeadOpportunities { get; }
    }
}
