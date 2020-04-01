using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Web.Iot.Models.Device;

namespace Web.Iot.APIGatewayService.Security
{
    public class TokenGenerator : IJwtTokenService
    {

        public string Generate(DeviceModel device, TokenParams tokenParams)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(tokenParams.Secret));

            var handler = new JwtSecurityTokenHandler();
            var descriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddHours(2),
                Issuer = tokenParams.Issuer,
                Audience = tokenParams.Audience,
                SigningCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.DeviceModel, device.Model),
                    new Claim(ClaimTypes.Manufacturer, device.Manufacturer),
                    new Claim(ClaimTypes.WifiHardwareAddress, device.MacAddress)
                })
            };

            var token = handler.CreateToken(descriptor);
            return handler.WriteToken(token);
        }

        public string GenerateFakeToken()
        {
            string fakeClaim = Guid.NewGuid().ToString();
            return Generate(new DeviceModel()
            {
                Manufacturer = fakeClaim,
                MacAddress = fakeClaim,
                Model = fakeClaim
            },
            new TokenParams(fakeClaim, fakeClaim, fakeClaim));
        }


        public bool Validate(string token, TokenParams tokenParams)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(tokenParams.Secret));

            var tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = tokenParams.Issuer,
                    ValidAudience = tokenParams.Audience,
                    IssuerSigningKey = secretKey
                }, out SecurityToken validatedToken);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
