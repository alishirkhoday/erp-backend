namespace ERP.Domain.Entities.Modules.ProductionManagement
{
    public class Operator : BaseEntity
    {
        public string FirstName { get; private set; } = default!;
        public string LastName { get; private set; } = default!;
        public string NationalCode { get; private set; } = default!;
        public string PersonnelCode { get; private set; } = default!;
        public string? PhoneNumber { get; private set; }

        public Operator(string firstName, string lastName, string nationalCode, string personnelCode, string? phoneNumber = null)
        {
            FirstName = firstName;
            LastName = lastName;
            NationalCode = nationalCode;
            PersonnelCode = personnelCode;
            PhoneNumber = phoneNumber;
        }
    }
}
