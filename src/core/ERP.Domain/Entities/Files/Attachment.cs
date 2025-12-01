namespace ERP.Domain.Entities.Files
{
    public class Attachment : BaseEntity
    {
        public string ReferenceId { get; private set; } = default!;
        public string ReferenceType { get; private set; } = default!;
        public string FileName { get; private set; } = default!;
        public string FilePath { get; private set; } = default!;
        public string UploadedBy { get; private set; } = default!;
        public DateTimeOffset UploadDateTime { get; private set; }

        private Attachment()
        {
        }

        public Attachment(string referenceId, string referenceType, string fileName, string filePath, string uploadedBy, DateTimeOffset uploadDateTime)
        {
            ArgumentException.ThrowIfNullOrEmpty(referenceId, nameof(referenceId));
            ArgumentException.ThrowIfNullOrEmpty(referenceType, nameof(referenceType));
            ArgumentException.ThrowIfNullOrEmpty(fileName, nameof(fileName));
            ArgumentException.ThrowIfNullOrEmpty(filePath, nameof(filePath));
            ArgumentException.ThrowIfNullOrWhiteSpace(filePath, nameof(filePath));
            ArgumentException.ThrowIfNullOrEmpty(uploadedBy, nameof(uploadedBy));
            ReferenceId = referenceId;
            ReferenceType = referenceType;
            FileName = fileName;
            FilePath = filePath;
            UploadedBy = uploadedBy;
            UploadDateTime = uploadDateTime;
        }
    }
}
