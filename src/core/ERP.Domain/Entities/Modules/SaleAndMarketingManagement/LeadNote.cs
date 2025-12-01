namespace ERP.Domain.Entities.Modules.SaleAndMarketingManagement
{
    public class LeadNote : BaseEntity
    {
        public Lead Lead { get; private set; } = default!;
        public string Note { get; private set; } = default!;

        private LeadNote()
        {
        }

        public LeadNote(Lead lead, string note)
        {
            ArgumentNullException.ThrowIfNull(lead, nameof(lead));
            ArgumentException.ThrowIfNullOrEmpty(note, nameof(note));
            Lead = lead;
            Note = note;
        }
    }
}
