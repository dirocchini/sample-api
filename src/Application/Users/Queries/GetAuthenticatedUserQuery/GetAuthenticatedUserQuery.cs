using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Support.Encrypt;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetAuthenticatedUserQuery
{
    public class GetAuthenticatedUserQuery : IRequest<string>
    {
        public string Email { get; set; }
        public string Password { get; set; }


        public class Handler : QueryBaseHandler, IRequestHandler<GetAuthenticatedUserQuery, string>
        {
            private readonly IEncrypter _encrypter;

            public Handler(IApplicationContext context, IMapper mapper, IEncrypter encrypter) : base(context, mapper)
            {
                _encrypter = encrypter;
            }

            public async Task<string> Handle(GetAuthenticatedUserQuery request, CancellationToken cancellationToken)
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == request.Email.ToLower().Trim());
                if (user == null)
                    throw new ArgumentException($"User {request.Email} not found");

                if (!user.ValidatePassword(request.Password, _encrypter))
                    throw new ArgumentException($"Incorrect password provided");


                return string.Empty;
            }
        }
    }
}
