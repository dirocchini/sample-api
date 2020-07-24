using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Notifications
{
    public class Notification
    {
        public string Key { get; }
        public string Message { get; }
        public Exception Exception { get; }

        public Notification(string key, string message, Exception exception)
        {
            Key = key;
            Message = message;
            Exception = exception;
        }
    }
}