using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Support.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(int userId);
    }
}
