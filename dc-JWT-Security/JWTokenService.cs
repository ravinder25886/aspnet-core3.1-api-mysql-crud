using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace dc_JWT_Security
{
    public class JWTokenService: IJWTokenService
    {
        private JWTSettings _appSettings;
        public JWTokenService(IOptions<JWTSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }
        public APIJWToken CreateToken(string UserId,string UserName)
        {
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JWTSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, UserName),
                    new Claim(ClaimTypes.NameIdentifier,UserId)
                }),
                Expires = DateTime.UtcNow.AddDays(_appSettings.ExpiresInDays),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            //token.ValidTo
            APIJWToken response = new APIJWToken();
            response.Token = tokenHandler.WriteToken(token);
            response.TokenExpiration = token.ValidTo;
            return response;
        }
    }
}
