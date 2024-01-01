using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SchoolOrganizer.Customers.Contracts;

namespace SchoolOrganizer.Notifications.Core.Services;

public interface INotificationsMessageProducer
{
    public void AddNotificationToQueue<T>(T message) where T: class;
}
public class NotificationsMessageProducer: INotificationsMessageProducer
{
    private readonly RabbitMQSettings _settings;

    public NotificationsMessageProducer(RabbitMQSettings settings)
    {
        _settings = settings;
    }
    public void AddNotificationToQueue<T>(T message) where T: class
    {
        var connectionFactory = new ConnectionFactory()
        {
            HostName = _settings.Address,
            Port = _settings.Port
        };
        var connection = connectionFactory.CreateConnection();

        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare(_settings.ChannelName, exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange:"", routingKey:_settings.ChannelName, body: body);
        }
    }
}