using System;
using Domain.Interfaces;
using Domain.Support.Encrypt;
using Shared.Constants;

namespace Domain.Entities
{
    public class User : IEntity
    {
        public int Id { get; }
        public string Name { get; }
        public string Email { get; }
        public string Password { get; private set; }
        public string Salt { get; private set; }
        public DateTime CreatedOn { get; }

        protected User() { }

        public User(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessage.DOMAIN_USER_NAME_INVALID);

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(ExceptionMessage.DOMAIN_USER_EMAIL_INVALID);

            Name = name;
            Email = email;
            CreatedOn = DateTime.Now;
        }

        public void SetPassword(string password, IEncrypter encrypter)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException(ExceptionMessage.DOMAIN_USER_PASSWORD_INVALID);

            Salt = encrypter.GetSalt();
            Password = encrypter.GetHash(password, Salt);
        }
    }
}