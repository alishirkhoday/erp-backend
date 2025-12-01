namespace ERP.Domain.Entities.Modules.HumanResourcesManagement
{
    public class HumanPerformanceReview : BaseEntity
    {
        public Human Human { get; private set; } = default!;
        public string ReviewerId { get; private set; } = default!;
        public DateOnly ReviewDate { get; private set; }
        public int Score { get; private set; }
        public string? Comment { get; private set; }
        public HumanPerformanceRating Rating => GetRating(Score);

        private HumanPerformanceReview()
        {
        }

        public HumanPerformanceReview(Human human, string reviewerId, DateOnly reviewDate, int score, string? comment = null)
        {
            ArgumentNullException.ThrowIfNull(human, nameof(human));
            if (score < 0 || score > 100)
                throw new ArgumentOutOfRangeException(nameof(score));
            Human = human;
            ReviewerId = reviewerId;
            ReviewDate = reviewDate;
            Score = score;
            Comment = comment;
        }

        private static HumanPerformanceRating GetRating(int score)
        {
            return score switch
            {
                >= 90 => HumanPerformanceRating.Excellent,
                >= 75 => HumanPerformanceRating.Good,
                >= 60 => HumanPerformanceRating.Average,
                >= 40 => HumanPerformanceRating.Poor,
                _ => HumanPerformanceRating.Unacceptable,
            };
        }
    }
}
