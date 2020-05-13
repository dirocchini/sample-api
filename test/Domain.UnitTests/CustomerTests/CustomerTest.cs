using System;
using System.Collections.Generic;
using Bogus;
using Domain.UnitTests._Builders;
using Domain.UnitTests._Common;
using ExpectedObjects;
using Shared.Constants;
using Xunit;

namespace Domain.UnitTests.CustomerTests
{
    public class CustomerTest
    {
        private readonly string _name;
        private readonly string _email;

        public CustomerTest()
        {
            var faker = new Faker();
            _name = faker.Name.FullName();
            _email = faker.Person.Email;
        }


        [Fact]
        public void customer_should_be_created()
        {
            var expectedCustomer = new
            {
                Name = _name,
                Email = _email
            };

            var customer = new Customer(expectedCustomer.Name, expectedCustomer.Email);
            expectedCustomer.ToExpectedObject().ShouldMatch(customer);

        }


        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData(null)]
        public void customer_email_should_not_be_null_or_empty(string email)
        {
            Assert.Throws<ArgumentException>(() => CustomerBuilder.New().WithEmail(email).Build()).WithMessage(ExceptionMessage.DOMAIN_CUSTOMER_EMAIL_INVALID);
        }


        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData(null)]
        public void customer_name_should_not_be_null_or_empty(string name)
        {
            Assert.Throws<ArgumentException>(() => CustomerBuilder.New().WithName(name).Build()).WithMessage(ExceptionMessage.DOMAIN_CUSTOMER_NAME_INVALID);
        }
    }



    public class Customer
    {
        public Customer(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(ExceptionMessage.DOMAIN_CUSTOMER_EMAIL_INVALID);

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessage.DOMAIN_CUSTOMER_NAME_INVALID);

            Name = name;
            Email = email;
            Orders = new List<Order>();
        }


        public string Name { get; }
        public string Email { get; }

        public List<Order> Orders { get; private set; } //todo test this?
    }
}
