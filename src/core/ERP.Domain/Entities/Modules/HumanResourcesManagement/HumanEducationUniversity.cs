namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanEducationUniversity : BaseEntity
    {
        public string Name { get; private set; } = default!;

        private HumanEducationUniversity()
        {
        }

        public HumanEducationUniversity(string name)
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
