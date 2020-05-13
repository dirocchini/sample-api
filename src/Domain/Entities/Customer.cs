using System;
using System.Collections.Generic;
using Shared.Constants;

namespace Domain.Entities
{
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