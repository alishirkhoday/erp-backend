namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class Job : BaseEntity
    {
        public string Name { get; private set; } = default!;

        private Job()
        {
        }

        public Job(string name)
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
