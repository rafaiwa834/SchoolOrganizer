namespace SchoolOrganizer.Notifications.Core;

public class NotificationMessageTemplate
{
    public string Receiver { get; set; }
    public string Message { get; set; }
    public NotificationsTypeEnum Type { get; set; }
    
}