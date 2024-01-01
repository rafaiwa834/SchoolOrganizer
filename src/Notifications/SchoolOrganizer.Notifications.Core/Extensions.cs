using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolOrganizer.Notifications.Core.Services;
using SchoolOrganizer.Shared.Infrastructure.Settings;

namespace SchoolOrganizer.Notifications.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqSettings = configuration.GetOptions<RabbitMQSettings>();
        services.AddSingleton(rabbitMqSettings);
        services.AddScoped<INotificationsMessageProducer, NotificationsMessageProducer>();
        return services;
    }
}