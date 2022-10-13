using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Authentication;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PortfolioApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IJWTAuthenticationManager _jWTAuthenticationManager;

    public AuthenticationController(IJWTAuthenticationManager jWTAuthenticationManager)
    {
        _jWTAuthenticationManager = jWTAuthenticationManager;
    }
    
    [HttpGet]
    public string Get()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();

        var adminPassword = configuration.GetConnectionString("AdminPassword");
        
        return adminPassword;
    }

    [HttpPost]
    public IActionResult Post([FromBody] string password)
    {
        var token = _jWTAuthenticationManager.Authenticate(password);

        if (token == "Not Authorized")
            return Unauthorized();

        return Ok(token);
    }
}
