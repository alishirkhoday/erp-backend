using ERP.Application.Common.Interfaces.Authentication;
using ERP.Application.Common.Interfaces.DbContext;
using ERP.Domain.Entities.Users;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Security.Cryptography;

namespace ERP.Infrastructure.Services.Authentication
{
    public sealed class OneTimePasswordService : IOneTimePasswordService
    {
        private readonly ICacheDbContext _context;
        private readonly IDatabase _db;

        private const int OtpTTLMinutes = 2;
        private const int RequestLimit = 5;
        private const int RateLimitMinutes = 10;

        public OneTimePasswordService(ICacheDbContext context)
        {
            _context = context.WithPrefix("otp:");
            _db = _context.Db;
        }

        private string CodeKey(string userId) => $"{_context.Prefix}code:{userId}";
        private string CountKey(string userId) => $"{_context.Prefix}count:{userId}";

        public async Task<Tuple<string?, bool>> GenerateAsync(string userId, OneTimePasswordChannel channel, CancellationToken cancellationToken = default)
        {
            var codeKey = CodeKey(userId);
            var countKey = CountKey(userId);

            // Atomic increment
            long count = await _db.StringIncrementAsync(countKey);

            // Set TTL on first request
            if (count == 1)
                await _db.KeyExpireAsync(countKey, TimeSpan.FromMinutes(RateLimitMinutes));

            if (count > RequestLimit)
                return new Tuple<string?, bool>(null, false);

            // Secure OTP 6-digit
            string code = RandomNumberGenerator.GetInt32(100000, 999999).ToString();

            //Todo : Hash code
            var otp = new OneTimePassword(userId, code, DateTimeOffset.UtcNow.AddMinutes(OtpTTLMinutes), channel);
            string json = JsonConvert.SerializeObject(otp);

            // Save OTP with TTL
            await _db.StringSetAsync(codeKey, json, TimeSpan.FromMinutes(OtpTTLMinutes));

            return new Tuple<string?, bool>(code, true);
        }

        public async Task<OneTimePassword?> GetByUserIdAsync(string userId, CancellationToken cancellationToken = default)
        {
            var codeKey = CodeKey(userId);
            var value = await _db.StringGetAsync(codeKey);
            if (value.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<OneTimePassword>(value);
        }

        public async Task<bool> VerifyAsync(string userId, string inputCode, CancellationToken cancellationToken = default)
        {
            var codeKey = CodeKey(userId);

            // LUA Script – get + delete atomically
            string script = @"
            local v = redis.call('GET', KEYS[1])
            if v then
                redis.call('DEL', KEYS[1])
            end
            return v
            ";

            var scriptEvaluate = await _db.ScriptEvaluateAsync(script, [codeKey], []);
            var result = scriptEvaluate.ToString();

            if (result is null)
                return false;

            var otp = JsonConvert.DeserializeObject<OneTimePassword>(result);

            if (otp == null)
                return false;

            if (otp.ExpireDate < DateTimeOffset.UtcNow)
                return false;

            return otp.Code == inputCode;
        }

        public async Task<int?> GetUserOTPCountAsync(string userId, CancellationToken cancellationToken = default)
        {
            var countKey = CountKey(userId);
            var val = await _db.StringGetAsync(countKey);
            if (val.IsNullOrEmpty)
                return 0;

            return int.Parse(val);
        }
    }
}
