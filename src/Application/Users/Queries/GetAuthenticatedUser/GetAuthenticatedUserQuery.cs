using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Support.Auth;
using Domain.Support.Encrypt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shared.Exceptions;

namespace Application.Users.Queries.GetAuthenticatedUser
{
    public class GetAuthenticatedUserQuery : IRequest<JsonWebToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public class Handler : QueryBaseHandler, IRequestHandler<GetAuthenticatedUserQuery, JsonWebToken>
        {
            private readonly IEncrypter _encrypter;
            private readonly IJwtHandler _jwtHandler;
            private readonly ILogger<Handler> _logger;

            public Handler(IApplicationContext context, IMapper mapper, IEncrypter encrypter, IJwtHandler jwtHandler, ILogger<Handler> logger) : base(context, mapper)
            {
                _encrypter = encrypter;
                _jwtHandler = jwtHandler;
                _logger = logger;
            }

            public async Task<JsonWebToken> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == request.Email.ToLower().Trim());
                if (user == null)
                    throw new UserNotFoundException($"User {request.Email} not found");

                if (!user.ValidatePassword(request.Password, _encrypter))
                    throw new IncorrectPasswordException($"Incorrect password provided");

                _logger.LogInformation($"User {user.Name} / {user.Email} logged in");

                return _jwtHandler.Create(user.Id);
            }
        }
    }
}
