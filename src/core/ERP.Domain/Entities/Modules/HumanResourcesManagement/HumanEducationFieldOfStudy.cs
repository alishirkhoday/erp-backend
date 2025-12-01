namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanEducationFieldOfStudy : BaseEntity
    {
        public string Name { get; private set; } = default!;

        private HumanEducationFieldOfStudy()
        {
        }

        public HumanEducationFieldOfStudy(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }

        public void Update(string name)
        {
            ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));
            Name = name;
        }
    }
}
