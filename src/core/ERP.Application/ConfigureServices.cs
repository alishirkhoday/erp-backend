using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ERP.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg =>
            {
                //cfg.LicenseKey = "eyJhbGciOiJSUzI1NiIsImtpZCI6Ikx1Y2t5UGVubnlTb2Z0d2FyZUxpY2Vuc2VLZXkvYmJiMTNhY2I1OTkwNGQ4OWI0Y2IxYzg1ZjA4OGNjZjkiLCJ0eXAiOiJKV1QifQ.eyJpc3MiOiJodHRwczovL2x1Y2t5cGVubnlzb2Z0d2FyZS5jb20iLCJhdWQiOiJMdWNreVBlbm55U29mdHdhcmUiLCJleHAiOiIxNzkzMTQ1NjAwIiwiaWF0IjoiMTc2MTY0MjEwNyIsImFjY291bnRfaWQiOiIwMTlhMmEwOGQ2OWM3ZGE3OWU3ZTU5NGI0N2EyZjk1YiIsImN1c3RvbWVyX2lkIjoiY3RtXzAxazhuMHRtNThicGo2amQzd3I4YXQ4YzdoIiwic3ViX2lkIjoiLSIsImVkaXRpb24iOiIwIiwidHlwZSI6IjIifQ.ufQJfnPZTUEjI-uGvKSZ9uqP0EQO1iMvaJwwJJ5AOe57df-aTtagJxd7xQfLNIUNt-i78PJsdk76HHvwGxsxsR1kOcpnRwgsHN564Maw_p7Dq-s-Lp7dN4qsR0vqmwiq6s3Ksq-jZ2jgyj_-cqMLbwRPl8Im6YcD53M0VViPp1pgU2HFokSxHd8xw4e5NTVlOkIOv9jYEFeIAY_Jo4lHGmLoY-9h88oQygVqDz6Z9KA0ZWNJoRjZuCGkmMrZBVgFhvpGogHFmw8x02SwKD6PRCVk7S5-eL_8v3FInvu9EhnWjskObP4tuUmjx_ZX0R3mutOJPF7QsPDPyp3tJTDtqg";
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
