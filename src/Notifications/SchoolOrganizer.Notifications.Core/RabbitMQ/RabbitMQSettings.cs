using SchoolOrganizer.Shared.Abstractions.Settings;

namespace SchoolOrganizer.Notifications.Core;

public class RabbitMQSettings: ISettings
{
    public string Address { get; set; }
    public int Port { get; set; }
    public string ChannelName { get; set; }
    public static string SectionName => "RabbitMQ";
}