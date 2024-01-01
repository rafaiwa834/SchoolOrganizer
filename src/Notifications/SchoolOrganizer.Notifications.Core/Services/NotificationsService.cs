using SchoolOrganizer.Customers.Contracts;

namespace SchoolOrganizer.Notifications.Core.Services;

public class NotificationsService
{
    private readonly ICustomersModuleClient _customersModuleClient;
    private readonly INotificationsMessageProducer _notificationsMessageProducer;

    public NotificationsService(ICustomersModuleClient customersModuleClient, INotificationsMessageProducer notificationsMessageProducer)
    {
        _customersModuleClient = customersModuleClient;
        _notificationsMessageProducer = notificationsMessageProducer;
    }

    public async Task ProduceMessage(List<Guid> parentIds, string message, NotificationsTypeEnum notificationsType, CancellationToken cancellationToken)
    {
        var parents = await _customersModuleClient.GetParents(parentIds, cancellationToken);
        foreach (var parent in parents)
        {
            NotificationMessageTemplate messageTemplate = CreateNotificationTemplate(notificationsType, message, parent);
            _notificationsMessageProducer.AddNotificationToQueue(messageTemplate);   
        }
    }

    private NotificationMessageTemplate CreateNotificationTemplate(NotificationsTypeEnum notificationsType, string message, ParentContractDto parent)
    {
        var receiver = notificationsType switch
        {
            NotificationsTypeEnum.All => $"{parent.Email};{parent.PhoneNumber}",
            NotificationsTypeEnum.EMAIL => parent.Email,
            NotificationsTypeEnum.SMS => parent.PhoneNumber,
        };
        return new NotificationMessageTemplate()
        {
            Receiver = receiver,
            Message = message,
            Type = notificationsType
        };
    }
}