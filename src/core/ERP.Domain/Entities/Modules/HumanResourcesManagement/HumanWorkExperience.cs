namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanWorkExperience : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public Company Company { get; private set; } = default!;
        public Job Job { get; private set; } = default!;
        public DateOnly StartDate { get; private set; }
        public DateOnly? EndDate { get; private set; }
        public string? Description { get; private set; }

        private HumanWorkExperience()
        {
        }

        public HumanWorkExperience(Human human, Company company, Job job, DateOnly startDate, DateOnly? endDate = null)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            ArgumentNullException.ThrowIfNull(company, nameof(company));
            ArgumentNullException.ThrowIfNull(job, nameof(job));
            Human = human;
            Company = company;
            Job = job;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Update(Company company, Job job, DateOnly startDate, DateOnly? endDate = null)
        {
            ArgumentNullException.ThrowIfNull(company, nameof(company));
            ArgumentNullException.ThrowIfNull(job, nameof(job));
            Company = company;
            Job = job;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void SetDescription(string? description) => Description = string.IsNullOrWhiteSpace(description) ? null : description.Trim();
    }
}
