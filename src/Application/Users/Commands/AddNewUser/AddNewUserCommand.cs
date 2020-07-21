using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Support.Encrypt;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Constants;

namespace Application.Users.Commands.AddNewUser
{
    public class AddNewUserCommand : IRequest<NewUserVm>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public class Handler : CommandBaseHandler, IRequestHandler<AddNewUserCommand, NewUserVm>
        {
            private readonly IEncrypter _encrypter;

            public Handler(IApplicationContext context, IMapper mapper, IEncrypter encrypter) : base(context, mapper)
            {
                _encrypter = encrypter;
            }

            public async Task<NewUserVm> Handle(AddNewUserCommand request, CancellationToken cancellationToken)
            {
                var user = await context.Users.FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == request.Email.ToLower().Trim(), cancellationToken);
                if(user != null)
                    throw new ArgumentException(ExceptionMessage.DOMAIN_USER_EMAIL_EXISTS);

                var newUser = new User(request.Name, request.Email);
                newUser.SetPassword(request.Password, _encrypter);

                await context.Users.AddAsync(newUser, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                return new NewUserVm
                    {Id = newUser.Id, Name = newUser.Name, Email = newUser.Email, CreatedOn = newUser.CreatedOn};
            }
        }
    }
}
