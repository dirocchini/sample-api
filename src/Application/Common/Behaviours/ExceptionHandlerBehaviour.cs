using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Notifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class ExceptionHandlerBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<TRequest> _logger;
        private readonly NotificationContext _notificationContext;

        public ExceptionHandlerBehaviour(ILogger<TRequest> logger, NotificationContext notificationContext)
        {
            _logger = logger;
            _notificationContext = notificationContext;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default(TResponse);

            try
            {
                response = await next();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "error captured");
                _notificationContext.AddSingleNotification("Custom Message", e.Message, e);
            }

            return response;
        }
    }
}