using System;
using System.Collections.Generic;
using Domain.Interfaces;
using Shared.Constants;

namespace Domain.Entities
{
    public class Customer : IEntity
    {
        public Customer(string name, string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException(ExceptionMessage.DOMAIN_CUSTOMER_EMAIL_INVALID);

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(ExceptionMessage.DOMAIN_CUSTOMER_NAME_INVALID);

            Name = name;
            Email = email;
        }

        public void AddOrder(Order order)
        {
            Orders ??= new List<Order>();
            Orders.Add(order);
        }


        public int Id { get; }

        public string Name { get; }
        public string Email { get; }

        public List<Order> Orders { get; private set; } //todo test this?
    }
}