using System.Text;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SchoolOrganizer.Customers.Contracts;

namespace SchoolOrganizer.Notifications.Core.Services;

public interface INotificationsMessageProducer
{
    public void SendNotificationMessage(NotificationMessageTemplate message);
}
public class NotificationsMessageProducer
{
    public void SendNotificationMessage(NotificationMessageTemplate message)
    {
        var connectionFactory = new ConnectionFactory()
        {
            HostName = "localhost"
        };
        var connection = connectionFactory.CreateConnection();

        using(var channel = connection.CreateModel())
        {
            channel.QueueDeclare("notifications", exclusive: false);
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange:"", routingKey:"notifications", body: body);
        }
    }
}