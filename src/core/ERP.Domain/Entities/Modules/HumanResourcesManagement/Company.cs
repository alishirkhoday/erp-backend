namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class Company : BaseEntity
    {
        public string Name { get; private set; } = default!;
        public string? Address { get; private set; }
        public string? Telephone { get; private set; }

        private Company()
        {
        }

        public Company(string name)
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
