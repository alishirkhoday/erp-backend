using ERP.Domain.Entities.Modules.FinanceManagement;
using ERP.Domain.Entities.Modules.HumanResourcesManagement.ValueObjects;
using ERP.Domain.Entities.Users;

namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class Human : BaseEntity
    {
        public Guid UserId { get; private set; } = default!;
        public User User { get; private set; } = default!;
        public NationalId NationalId { get; private set; } = default!;
        public string Name { get; private set; } = default!;
        public string Family { get; private set; } = default!;
        public HumanGender Gender { get; private set; }
        public DateOnly BirthDate { get; private set; }
        public bool MaritalStatus { get; private set; }
        public PassportId PassportId { get; private set; } = default!;
        public HumanStatus Status { get; private set; }
        public Address Address { get; private set; } = default!;

        private readonly List<HumanContactInformation> _contactInformation = [];
        public IReadOnlyList<HumanContactInformation> ContactInformation => _contactInformation;

        private readonly List<HumanBankAccount> _bankAccounts = [];
        public IReadOnlyList<HumanBankAccount> BankAccounts => _bankAccounts;

        private readonly List<HumanEducation> _educations = [];
        public IReadOnlyList<HumanEducation> Educations => _educations;

        private readonly List<HumanWorkExperience> _workExperiences = [];
        public IReadOnlyList<HumanWorkExperience> WorkExperiences => _workExperiences;

        private readonly List<HumanContract> _contracts = [];
        public IReadOnlyList<HumanContract> Contracts => _contracts;

        private readonly List<HumanAttendanceRecord> _attendanceRecords = [];
        public IReadOnlyList<HumanAttendanceRecord> AttendanceRecords => _attendanceRecords;

        private readonly List<HumanLeaveRequest> _leaveRequests = [];
        public IReadOnlyList<HumanLeaveRequest> LeaveRequests => _leaveRequests;

        private readonly List<Payroll> _payrolls = [];
        public IReadOnlyList<Payroll> Payrolls => _payrolls;

        private Human()
        {
        }

        public Human(User user, string nationalId, string name, string family, HumanGender gender, DateOnly birthDate, bool maritalStatus, string? passportId = null)
        {
            ArgumentNullException.ThrowIfNull(user, nameof(user));
            ArgumentException.ThrowIfNullOrWhiteSpace(nationalId, nameof(nationalId));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(family, nameof(family));
            if (birthDate > new DateOnly(1700, 1, 1))
                throw new ArgumentException("BirthDate should be greater than 1700/01/01.", nameof(birthDate));
            User = user;
            UserId = user.Id;
            NationalId = nationalId;
            Name = name;
            Family = family;
            Gender = gender;
            BirthDate = birthDate;
            MaritalStatus = maritalStatus;
            PassportId = passportId;
            Status = HumanStatus.Active;
        }

        public void Update(string nationalId, string name, string family, HumanGender gender, DateOnly birthDate, bool maritalStatus, string? passportId = null)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(nationalId, nameof(nationalId));
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            ArgumentException.ThrowIfNullOrEmpty(family, nameof(family));
            if (birthDate > new DateOnly(1700, 1, 1))
                throw new ArgumentException("BirthDate should be greater than 1700/01/01.", nameof(birthDate));
            NationalId = nationalId;
            Name = name;
            Family = family;
            Gender = gender;
            BirthDate = birthDate;
            MaritalStatus = maritalStatus;
            PassportId = passportId;
        }

        public void ChangeStatus(HumanStatus status) => Status = status;
        public void SetAddress(Address address) => Address = address;
        public void AddContactInformation(HumanContactInformation contactInformation) => _contactInformation.Add(contactInformation);
        public void AddBankAccount(HumanBankAccount bankAccount) => _bankAccounts.Add(bankAccount);
        public void AddEducation(HumanEducation education) => _educations.Add(education);
        public void AddWorkExperience(HumanWorkExperience workExperience) => _workExperiences.Add(workExperience);
        public void AddContract(HumanContract contract) => _contracts.Add(contract);
        public void AddAttendanceRecord(HumanAttendanceRecord attendanceRecord) => _attendanceRecords.Add(attendanceRecord);
        public void AddLeaveRequest(HumanLeaveRequest leaveRequest) => _leaveRequests.Add(leaveRequest);
        public void AddPayroll(Payroll payroll) => _payrolls.Add(payroll);
    }
}
