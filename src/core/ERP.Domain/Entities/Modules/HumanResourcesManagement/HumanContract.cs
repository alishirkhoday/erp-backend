namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanContract : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public Position Position { get; private set; } = default!;
        public HumanEmploymentType EmploymentType { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public string? Description { get; private set; }
        public DateOnly? TerminationDate { get; private set; }
        public string? TerminationDescription { get; private set; }

        private HumanContract()
        {
        }

        public HumanContract(Human human, Position position, HumanEmploymentType employmentType, DateOnly startDate, DateOnly endDate)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            ArgumentNullException.ThrowIfNull(position, nameof(position));
            Human = human;
            Position = position;
            EmploymentType = employmentType;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Update(Position position, HumanEmploymentType employmentType, DateOnly startDate, DateOnly endDate)
        {
            ArgumentNullException.ThrowIfNull(position, nameof(position));
            Position = position;
            EmploymentType = employmentType;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetTerminationDate(DateOnly terminationDate, string terminationDescription)
        {
            TerminationDate = terminationDate;
            TerminationDescription = terminationDescription;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
