namespace PortfolioApi.Authentication;

public interface IJWTAuthenticationManager
{
    string Authenticate(string password);
}
