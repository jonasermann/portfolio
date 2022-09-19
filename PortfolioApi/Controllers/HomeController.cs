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
    public async Task<HomeContentDTO> GetHomeContent() => await _repo.GetHomeContent();

    [HttpGet("Home-History")]
    public async Task<List<HomeHistoryDTO>> GetHomeHistory() => await _repo.GetHomeHistory();

    [HttpGet("Home-Links")]
    public async Task<List<HomeLinkDTO>> GetHomeLinks() => await _repo.GetHomeLinks();
}
