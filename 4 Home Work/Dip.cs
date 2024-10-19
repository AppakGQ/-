using System;

public interface INotificationSender
{
    void Send(string message);
}

public class EmailSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("Email sent: " + message);
    }
}

public class SmsSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("SMS sent: " + message);
    }
}

public class MessengerSender : INotificationSender
{
    public void Send(string message)
    {
        Console.WriteLine("Message sent via Messenger: " + message);
    }
}

public class NotificationService
{
    private readonly INotificationSender[] _notificationSenders;

    public NotificationService(INotificationSender[] notificationSenders)
    {
        _notificationSenders = notificationSenders;
    }

    public void SendNotification(string message)
    {
        foreach (var sender in _notificationSenders)
        {
            sender.Send(message);
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        INotificationSender[] senders = new INotificationSender[]
        {
            new EmailSender(),
            new SmsSender(),
            new MessengerSender()
        };

        NotificationService notificationService = new NotificationService(senders);
        notificationService.SendNotification("Hello, this is a notification!");
    }
}
