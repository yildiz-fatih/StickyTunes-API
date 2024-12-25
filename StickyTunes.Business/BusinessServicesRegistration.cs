using Microsoft.Extensions.DependencyInjection;
using StickyTunes.Business.Services.Implementations;
using StickyTunes.Business.Services.Interfaces;

namespace StickyTunes.Business;

public static class BusinessServicesRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<SpotifyService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<IReactionService, ReactionService>();
        
        return services;
    }
}