using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    private IHomeRepository _repo;
    public HomeController(IHomeRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("Home-Content"), AllowAnonymous]
    public async Task<HomeContentDTO> GetGetHomeContent() => await _repo.GetHomeContent();

    [HttpPut("Home-Content"), AllowAnonymous]
    public async Task<HomeContentDTO> PutGetHomeContent(HomeContentDTO HomeContentDTO) => await _repo.PutHomeContent(HomeContentDTO);

    [HttpGet("Home-Links"), AllowAnonymous]
    public async Task<List<HomeLinkDTO>> GetHomeLinks() => await _repo.GetHomeLinks();

    [HttpGet("Home-Links/{id}"), AllowAnonymous]
    public async Task<HomeLinkDTO> GetHomeLink(int id) => await _repo.GetHomeLink(id);

    [HttpPost("Home-Links")]
    public async Task<HomeLinkDTO> AddHomeLink(HomeLinkCreateDTO HomeLinkCreateDTO) => await _repo.AddHomeLink(HomeLinkCreateDTO);

    [HttpPut("Home-Links")]
    public async Task<HomeLinkDTO> PutHomeLink(HomeLinkDTO HomeLinkDTO) => await _repo.PutHomeLink(HomeLinkDTO);

    [HttpDelete("Home-Links/{id}")]
    public async Task DeleteHomeLink(int id) => await _repo.DeleteHomeLink(id);
}
