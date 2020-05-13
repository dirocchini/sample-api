using System;
using System.Collections.Generic;
using System.Text;
using Bogus;
using Domain.UnitTests.CustomerTests;

namespace Domain.UnitTests._Builders
{
    public class CustomerBuilder
    {
        private string _name = new Faker().Name.FullName();
        private string _email = new Faker().Person.Email;

        public static CustomerBuilder New()
        {
            return new CustomerBuilder();
        }

        public CustomerBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public CustomerBuilder WithEmail(string email)
        {
            _email = email;
            return this;
        }

        public Customer Build()
        {
            return new Customer(_name, _email);
        }
    }
}
