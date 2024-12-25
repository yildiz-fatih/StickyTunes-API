using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StickyTunes.Data.Models;

namespace StickyTunes.Data;

public static class DataServicesRegistration
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<StickyTunesDbContext>(options => { options.UseMySQL(connectionString); });
        
        services.AddIdentity<ApiUser, ApiRole>()
            .AddEntityFrameworkStores<StickyTunesDbContext>()
            .AddDefaultTokenProviders();
        
        return services;
    }
}