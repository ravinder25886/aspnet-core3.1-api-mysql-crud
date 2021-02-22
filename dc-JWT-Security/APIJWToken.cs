using System;

namespace dc_JWT_Security
{
    public class APIJWToken
    {
        public string Token { get; set; }
        public DateTime TokenExpiration { get; set; }
    }
}
