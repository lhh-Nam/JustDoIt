using JDI.Core.Application.Common.Interfaces;
using JDI.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace JDI.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void RegisterDbContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(
            options => options.UseSqlServer(connectionString, optionsBuilder => optionsBuilder.EnableRetryOnFailure(
                10,
                TimeSpan.FromSeconds(30),
                null
                )));
        services.AddScoped<IApplicationDbContext>(c => c.GetService<ApplicationDbContext>());
    }
}