namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanEducation : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public HumanEducationFieldOfStudy FieldOfStudy { get; private set; } = default!;
        public HumanEducationUniversity University { get; private set; } = default!;
        public HumanEducationDegree Degree { get; private set; }
        public DateOnly StartDate { get; private set; }
        public DateOnly? GraduationDate { get; private set; }

        private HumanEducation()
        {
        }

        public HumanEducation(Human human, HumanEducationFieldOfStudy fieldOfStudy, HumanEducationUniversity university, HumanEducationDegree degree, DateOnly startDate, DateOnly? graduationDate = null)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            ArgumentNullException.ThrowIfNull(fieldOfStudy, nameof(fieldOfStudy));
            ArgumentNullException.ThrowIfNull(university, nameof(university));
            Human = human;
            FieldOfStudy = fieldOfStudy;
            University = university;
            Degree = degree;
            StartDate = startDate;
            GraduationDate = graduationDate;
        }

        public void Update(HumanEducationFieldOfStudy fieldOfStudy, HumanEducationUniversity university, HumanEducationDegree degree, DateOnly startDate, DateOnly? graduationDate = null)
        {
            ArgumentNullException.ThrowIfNull(fieldOfStudy, nameof(fieldOfStudy));
            ArgumentNullException.ThrowIfNull(university, nameof(university));
            FieldOfStudy = fieldOfStudy;
            University = university;
            Degree = degree;
            StartDate = startDate;
            GraduationDate = graduationDate;
        }

        public void SetGraduationDate(DateOnly graduationDate) => GraduationDate = graduationDate;
    }
}
