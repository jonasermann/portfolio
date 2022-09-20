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
    public async Task<HomeContentDTO> GetGetHomeContent() => await _repo.GetHomeContent();

    [HttpPut("Home-Content")]
    public async Task<HomeContentDTO> PutGetHomeContent(HomeContentDTO HomeContentDTO) => await _repo.PutHomeContent(HomeContentDTO);




    [HttpGet("Home-Histories")]
    public async Task<List<HomeHistoryDTO>> GetHomeHistories() => await _repo.GetHomeHistories();

    [HttpGet("Home-Histories/{id}")]
    public async Task<HomeHistoryDTO> GetHomeHistory(int id) => await _repo.GetHomeHistory(id);

    [HttpPost("Home-Histories")]
    public async Task<HomeHistoryDTO> AddHomeHistory(HomeHistoryCreateDTO HomeHistoryCreateDTO) => await _repo.AddHomeHistory(HomeHistoryCreateDTO);

    [HttpPut("Home-Histories")]
    public async Task<HomeHistoryDTO> PutHomeHistory(HomeHistoryDTO HomeHistoryDTO) => await _repo.PutHomeHistory(HomeHistoryDTO);

    [HttpDelete("Home-Histories/{id}")]
    public async Task DeleteHomeHistory(int id) => await _repo.DeleteHomeHistory(id);




    [HttpGet("Home-Links")]
    public async Task<List<HomeLinkDTO>> GetHomeLinks() => await _repo.GetHomeLinks();

    [HttpGet("Home-Links/{id}")]
    public async Task<HomeLinkDTO> GetHomeLink(int id) => await _repo.GetHomeLink(id);

    [HttpPost("Home-Links")]
    public async Task<HomeLinkDTO> AddHomeLink(HomeLinkCreateDTO HomeLinkCreateDTO) => await _repo.AddHomeLink(HomeLinkCreateDTO);

    [HttpPut("Home-Links")]
    public async Task<HomeLinkDTO> PutHomeLink(HomeLinkDTO HomeLinkDTO) => await _repo.PutHomeLink(HomeLinkDTO);

    [HttpDelete("Home-Links/{id}")]
    public async Task DeleteHomeLink(int id) => await _repo.DeleteHomeLink(id);
}
