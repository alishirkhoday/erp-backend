namespace ERP.Domain.Entities.Users.ValueObjects
{
    public class Image : ValueObject
    {
        public string FileName { get; private set; } = default!;
        public string FilePath { get; private set; } = default!;
        public string Alt { get; private set; } = default!;

        private Image()
        {
        }

        public Image(string fileName, string filePath, string alt)
        {
            ArgumentException.ThrowIfNullOrEmpty(fileName, nameof(fileName));
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));
            ArgumentException.ThrowIfNullOrEmpty(alt, nameof(alt));
            FileName = fileName;
            FilePath = filePath;
            Alt = alt;
        }

        protected override IEnumerable<object?> GetEqualityComponents()
        {
            yield return FileName;
            yield return FilePath;
            yield return Alt;
        }
    }
}
