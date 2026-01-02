using AITech.WebUI.Services.BannerServices;
using AITech.WebUI.Services.CategoryServices;
using AITech.WebUI.Services.GeminiServices;
using AITech.WebUI.Services.ProjectServices;
using FluentValidation;
using FluentValidation.AspNetCore;
using System.Reflection;

namespace AITech.WebUI.Extensions
{
    public static class ServiceRegistrations
    {
        public static void AddWebUIServices(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IBannerService, BannerService>();
            services.AddScoped<IGeminiService, GeminiService>();

            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
