using System;
using System.Collections.Generic;
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
            var user = new User("Admin", "admin@domain.com");
            user.SetPassword("123", _encrypter);

            await _applicationContext.Users.AddAsync(user);
            await _applicationContext.SaveChangesAsync(new CancellationToken());
        }
    }
}
