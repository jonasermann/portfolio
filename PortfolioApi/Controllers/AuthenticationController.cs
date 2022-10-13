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

    [HttpPost]
    public IActionResult Post(string password)
    {
        var token = _jWTAuthenticationManager.Authenticate(password);

        if (token == "Not Authorized")
            return Unauthorized();

        return Ok(token);
    }
}
