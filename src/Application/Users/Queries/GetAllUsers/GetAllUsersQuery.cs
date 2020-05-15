using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Handlers;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Users.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<AllUsersVm>
    {
        public class Handler : CommandBaseHandler, IRequestHandler<GetAllUsersQuery, AllUsersVm>
        {
            public Handler(IApplicationContext context, IMapper mapper) : base(context, mapper)
            {
            }

            public async Task<AllUsersVm> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await context.Users.ProjectTo<UserDto>(mapper.ConfigurationProvider).ToListAsync(cancellationToken);

                var allUsers = new AllUsersVm()
                {
                    Users = users
                };

                return allUsers;
            }
        }
    }
}
