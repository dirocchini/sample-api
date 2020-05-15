using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Users.Queries.GetAllUsers
{
    public class AllUsersVm
    {
        public AllUsersVm()
        {
            Users = new List<UserDto>();
        }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
