using AktifTech.CustomerOrderRestApi.EntityFramework;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AktifTech.CustomerOrderRestApi.Extensions;

public static class AppExtensions
{
    public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder builder)
    {
        using (var serviceScope = builder.ApplicationServices
            .GetRequiredService<IServiceScopeFactory>()
            .CreateScope())
        {
            using (var context = serviceScope.ServiceProvider.GetService<AppDbContext>())
            {
                context.Database.Migrate();
            }
        }

        return builder;
    }
}

