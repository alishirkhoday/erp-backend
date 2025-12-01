namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanLeaveRequest : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public HumanLeaveType Type { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly EndDate { get; private set; }
        public string? Reason { get; private set; }
        public HumanLeaveStatus Status { get; private set; }

        private HumanLeaveRequest()
        {
        }

        public HumanLeaveRequest(Human human, HumanLeaveType type, DateOnly start, DateOnly end, string? reason = null)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            Human = human;
            Type = type;
            StartDate = start;
            EndDate = end;
            Reason = reason;
            Status = HumanLeaveStatus.Pending;
        }

        public void SetApprove() => Status = HumanLeaveStatus.Approved;
        public void SetReject() => Status = HumanLeaveStatus.Rejected;
        public void SetCancel() => Status = HumanLeaveStatus.Cancelled;
    }
}
