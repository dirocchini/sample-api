using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore.Internal;

namespace Application.Notifications
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications;
        private Notification _notification;

        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasSingleNotification => _notification != null;
        public bool HasMultiNotifications => _notifications.Any();

        public NotificationContext()
        {
            _notifications = new List<Notification>();
        }

        public void AddSingleNotification(string key, string message, Exception e = null)
        {
            _notification = new Notification(key, message, e);
        }


        public void AddNotification(string key, string message, Exception e = null)
        {
            _notifications.Add(new Notification(key, message, e));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IReadOnlyCollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(IList<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ICollection<Notification> notifications)
        {
            _notifications.AddRange(notifications);
        }

        public void AddNotifications(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                AddNotification(error.ErrorCode, error.ErrorMessage);
            }
        }

        public Notification GetNotification()
        {
            return _notification;
        }
    }
}