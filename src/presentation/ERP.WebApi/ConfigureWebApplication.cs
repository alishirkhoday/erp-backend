namespace ERP.WebApi
{
    public static class ConfigureWebApplication
    {
        public static IApplicationBuilder AddWebApplications(this WebApplication app)
        {
            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("Default");

            return app;
        }
    }
}
