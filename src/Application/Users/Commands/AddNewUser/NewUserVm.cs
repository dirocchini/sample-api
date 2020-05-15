using System;

namespace Application.Users.Commands.AddNewUser
{
    public class NewUserVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}