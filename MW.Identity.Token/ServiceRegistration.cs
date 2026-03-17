using Microsoft.Extensions.DependencyInjection;
using MW.Identity.Token.Abstractions;
using MW.Identity.Token.Concretes;

namespace MW.Identity.Token;

public static class ServiceRegistration
{
    public static void AddUserTokenManger(this IServiceCollection services)
    {
        services.AddScoped<IUserTokenManager, UserTokenManager>();
    }
}