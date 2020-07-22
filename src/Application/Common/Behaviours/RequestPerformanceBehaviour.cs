using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Common.Behaviours
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly Stopwatch _timer;
        private readonly ILogger<TRequest> _logger;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();

            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            const int maxRequestTimeMilliseconds = 30;

            if (_timer.ElapsedMilliseconds > maxRequestTimeMilliseconds)
            {
                var name = typeof(TRequest).Name;
                _logger.LogWarning("Long Running Request Detected (over {maxRequestMillisecondsAllowed}): Message -> {requestName}, Duration -> ({elapsedMilliseconds} milliseconds), Request -> {request}",
                    maxRequestTimeMilliseconds, name, _timer.ElapsedMilliseconds, request);

            }

            return response;
        }
    }
}