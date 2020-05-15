using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Support.Encrypt;

namespace Persistence
{
    public class ApplicationDbSeed : IApplicationSeed
    {
        private readonly IApplicationContext _applicationContext;
        private readonly IEncrypter _encrypter;

        public ApplicationDbSeed(IApplicationContext applicationContext, IEncrypter encrypter)
        {
            _applicationContext = applicationContext;
            _encrypter = encrypter;
        }


        public async Task Seed()
        {
            if (!_applicationContext.Users.Any())
            {
                var user = new User("Admin", "admin@domain.com");
                user.SetPassword("123", _encrypter);
                await _applicationContext.Users.AddAsync(user);
                await _applicationContext.SaveChangesAsync(new CancellationToken());



                List<Customer> customers = new List<Customer>()
                {
                    new Customer("Dorothy", "dorothy@domain.com"),
                    new Customer("Annmarie", "annmarie@domain.com"),
                    new Customer("Ashley", "ashley@domain.com")
                };
                await _applicationContext.Customers.AddRangeAsync(customers);



                List<Order> orders = new List<Order>()
                {
                    new Order("Mother's Day buying", 1, new List<OrderItem>()
                    {
                        new OrderItem(2, 2235.3, "SKU 0012563"),
                        new OrderItem(7, 543.87, "SKU 5566547")
                    }),
                    new Order("Home office tools", 1, new List<OrderItem>()
                    {
                        new OrderItem(6, 224.2, "SKU 6573365"),
                    }),
                    new Order("Desktop upgrade", 2, new List<OrderItem>()
                    {
                        new OrderItem(3, 112.7, "SKU 1101232"),
                    })
                };
                await _applicationContext.Orders.AddRangeAsync(orders);

                await _applicationContext.SaveChangesAsync(new CancellationToken());
            }
        }
    }
}
