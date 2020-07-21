using System;
using Bogus;
using Domain.Entities;
using Domain.UnitTests._Builders;
using Domain.UnitTests._Common;
using ExpectedObjects;
using Shared.Constants;
using Xunit;

namespace Domain.UnitTests.UserTests
{
    public class UserTests
    {
        private string _name;
        private string _email;

        public UserTests()
        {
            var faker = new Faker();
            _name = faker.Person.FullName;
            _email = faker.Person.Email;
        }

        [Fact]
        public void user_should_be_created()
        {
            var expectedUser = new
            {
                Name = _name,
                Email = _email
            };

            var user = new User(expectedUser.Name,expectedUser.Email);
            expectedUser.ToExpectedObject().ShouldMatch(user);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void user_name_should_not_be_null_or_empty(string name)
        {
            Assert.Throws<ArgumentException>(() => UserBuilder.New().WithName(name).Build()).WithMessage(ExceptionMessage.DOMAIN_USER_NAME_INVALID);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void user_email_should_not_be_null_or_empty(string email)
        {
            Assert.Throws<ArgumentException>(() => UserBuilder.New().WithEmail(email).Build()).WithMessage(ExceptionMessage.DOMAIN_USER_EMAIL_INVALID);
        }
    }
}
