namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanAttendanceRecord : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public DateOnly Date { get; private set; }
        public HumanAttendanceStatus Status { get; private set; }
        public TimeOnly? EntryTime { get; private set; }
        public TimeOnly? ExitTime { get; private set; }

        private HumanAttendanceRecord()
        {
        }

        public HumanAttendanceRecord(Human human, DateOnly date)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            Human = human;
            Date = date;
            Status = HumanAttendanceStatus.Absent;
        }

        public void SetEntryTime(TimeOnly time)
        {
            EntryTime = time;
            Status = HumanAttendanceStatus.Present;
        }

        public void SetExitTime(TimeOnly time)
        {
            ExitTime = time;
        }

        public void MarkAsRemoteWork() => Status = HumanAttendanceStatus.RemoteWork;
    }
}
