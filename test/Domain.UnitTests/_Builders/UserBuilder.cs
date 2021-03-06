﻿using Bogus;
using Domain.Entities;

namespace Domain.UnitTests._Builders
{
    public class UserBuilder
    {
        private string _name = new Faker().Person.FullName;
        private string _email = new Faker().Person.Email;

        public static UserBuilder New()
        {
            return new UserBuilder();
        }

        public UserBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public UserBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }


        public User Build()
        {
            return new User(_name, _email);
        }
    }
}
