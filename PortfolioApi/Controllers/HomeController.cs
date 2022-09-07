using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private IHomeRepository _repo;

    public HomeController(IHomeRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("Home-Content")]
    public HomeContentDTO GetHomeContent() => _repo.GetHomeContent();

    [HttpGet("Home-History")]
    public List<HomeHistoryDTO> GetHomeHistory() => _repo.GetHomeHistory();

    [HttpGet("Home-Links")]
    public List<HomeLinksDTO> GetHomeLinks() => _repo.GetHomeLinks();
}
