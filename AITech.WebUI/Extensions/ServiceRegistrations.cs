using AITech.WebUI.Services.CategoryServices;

namespace AITech.WebUI.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddWebUIServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<ICategoryService, CategoryService>();
        }
    }
}
