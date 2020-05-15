using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Support.Auth
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }
}
