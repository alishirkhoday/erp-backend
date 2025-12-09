namespace ERP.Domain.Entities.Users.Normalization
{
    public static class NormalizationService
    {
        public static string ToNormalization(this string value)
        {
            return value.ToLowerInvariant().Trim();
        }
    }
}
