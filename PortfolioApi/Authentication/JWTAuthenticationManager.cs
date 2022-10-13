using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PortfolioApi.Authentication;

public class JWTAuthenticationManager : IJWTAuthenticationManager
{
    private readonly string _tokenKey;
    private IConfiguration _configuration;

    public JWTAuthenticationManager(string tokenKey, IConfiguration configuration)
    {
        _tokenKey = tokenKey;
        _configuration = configuration;
    }

    public string Authenticate(string password)
    {

        var adminPassword = _configuration["AdminPassword"];

        //if (!(password == adminPassword))
        //{
        //    return "Not Authorized";
        //}

        //var tokenHandler = new JwtSecurityTokenHandler();
        //var key = Encoding.ASCII.GetBytes(_tokenKey);
        //var tokenDescriptor = new SecurityTokenDescriptor
        //{
        //    Subject = new ClaimsIdentity(new Claim[]
        //    {
        //        new Claim(ClaimTypes.Name, "admin")
        //    }),
        //    Expires = DateTime.UtcNow.AddMinutes(2),
        //    SigningCredentials = new SigningCredentials(
        //        new SymmetricSecurityKey(key),
        //        SecurityAlgorithms.HmacSha256Signature)
        //};
        //var token = tokenHandler.CreateToken(tokenDescriptor);
        //return tokenHandler.WriteToken(token);
        return adminPassword;
    }
}
