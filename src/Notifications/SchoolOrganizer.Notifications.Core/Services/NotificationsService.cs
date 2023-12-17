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

    public async Task ProduceEmailMessage(Guid parentId, string message, CancellationToken cancellationToken)
    {
        var parent = await _customersModuleClient.GetParent(parentId, cancellationToken);
        var messageTemplate = new NotificationMessageTemplate()
        {
            Receiver = $@"{parent.FirstName} {parent.LastName}",
            Email = parent.Email,
            Message = message
        };
        _notificationsMessageProducer.SendNotificationMessage(messageTemplate);
    }
    
    public async Task ProduceSmsMessage(Guid parentId, string message, CancellationToken cancellationToken)
    {
        var parent = await _customersModuleClient.GetParent(parentId, cancellationToken);
        var messageTemplate = new NotificationMessageTemplate()
        {
            Receiver = $@"{parent.FirstName} {parent.LastName}",
            PhoneNumber = parent.PhoneNumber,
            Message = message
        };
        _notificationsMessageProducer.SendNotificationMessage(messageTemplate);
    }
    
    public async Task ProduceMessage(Guid parentId, string message, CancellationToken cancellationToken)
    {
        var parent = await _customersModuleClient.GetParent(parentId, cancellationToken);
        var messageTemplate = new NotificationMessageTemplate()
        {
            Receiver = $@"{parent.FirstName} {parent.LastName}",
            Email = parent.Email,
            PhoneNumber = parent.PhoneNumber,
            Message = message
        };
        _notificationsMessageProducer.SendNotificationMessage(messageTemplate);
    }
}