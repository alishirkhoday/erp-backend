namespace ERP.Application.Common
{
    public class Error
    {
        public string Code { get; }
        public string Message { get; }

        public Error(string code, string message)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(code, nameof(code));
            ArgumentException.ThrowIfNullOrEmpty(message, nameof(message));
            Code = code;
            Message = message;
        }
    }
}
