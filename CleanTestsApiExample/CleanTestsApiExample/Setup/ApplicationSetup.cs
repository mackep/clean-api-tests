using Microsoft.AspNetCore.Builder;

namespace CleanTestsApiExample.Setup
{
    public static class ApplicationSetup
    {
        public static void ConfigureApplication(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}