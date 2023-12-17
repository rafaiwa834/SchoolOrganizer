namespace SchoolOrganizer.Notifications.Core;

public class NotificationMessageTemplate
{
    public string Receiver { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string Message { get; set; }
    
}