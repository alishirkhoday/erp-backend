using ERP.Domain.Entities.Users;

namespace ERP.Application.Services.Authentication
{
    public interface ITokenService
    {
        string GenerateJsonWebToken(User user, DateTimeOffset expireDate);
    }
}
