using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Text;

namespace PortfolioApi.Authentication;

public class JWTAuthenticationManager : IJWTAuthenticationManager
{
    private readonly string _tokenKey;

    public JWTAuthenticationManager(string tokenKey)
    {
        _tokenKey = tokenKey;
    }

    public string Authenticate(string password)
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();

        var adminPassword = configuration.GetConnectionString("AdminPassword");


        return adminPassword;
    }
}
