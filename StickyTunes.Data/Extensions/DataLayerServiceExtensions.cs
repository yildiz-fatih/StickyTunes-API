using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StickyTunes.Data.Models;
using StickyTunes.Data.Repositories.Implementations;
using StickyTunes.Data.Repositories.Interfaces;

namespace StickyTunes.Data.Extensions;

public static class DataLayerServiceExtensions
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<StickyTunesDbContext>(options => { options.UseMySQL(connectionString); });
        
        services.AddIdentity<ApiUser, ApiRole>()
            .AddEntityFrameworkStores<StickyTunesDbContext>()
            .AddDefaultTokenProviders();

        services.AddScoped<ICommentRepository, CommentRepository>();
        
        return services;
    }
}