using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Notifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using Shared.Exceptions;

namespace WebApi.Filters.Notifications
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;

        public NotificationFilter(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasSingleNotification)
            {
                int code;

                var notification = _notificationContext.GetNotification();

                switch (notification.Exception)
                {
                    case IncorrectPasswordException _:
                    case UserNotFoundException _:
                        code = (int)HttpStatusCode.Unauthorized;
                        break;
                    case CustomerAlreadyRegisteredException _:
                        code = (int)HttpStatusCode.Conflict;
                        break;
                    default:
                        code = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                context.HttpContext.Response.StatusCode = code;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(new Error(notification.Message, notification.Exception.StackTrace));

                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            if (_notificationContext.HasMultiNotifications)
            {
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
                await context.HttpContext.Response.WriteAsync(notifications);

                return;
            }

            await next();
        }


    }

    public class Error
    {
        public string Message { get; }
        public string Stack { get; }

        public Error(string message, string stack)
        {
            Message = message;
            Stack = stack;
        }
    }
}