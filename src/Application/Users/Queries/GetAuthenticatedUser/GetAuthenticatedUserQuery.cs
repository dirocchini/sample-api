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

            public Handler(IApplicationContext context, IMapper mapper, IEncrypter encrypter, IJwtHandler jwtHandler) : base(context, mapper)
            {
                _encrypter = encrypter;
                _jwtHandler = jwtHandler;
            }

            public async Task<JsonWebToken> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == request.Email.ToLower().Trim());
                if (user == null)
                    throw new ArgumentException($"User {request.Email} not found");

                if (!user.ValidatePassword(request.Password, _encrypter))
                    throw new ArgumentException($"Incorrect password provided");


                return _jwtHandler.Create(user.Id);
            }
        }
    }
}
