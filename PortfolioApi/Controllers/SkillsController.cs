using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Repositories;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillsController : ControllerBase
{
    private ISkillsRepository _repo;
    public SkillsController(ISkillsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("Backend")]
    public async Task<List<SkillDTO>> GetBackend() => await _repo.GetBackend();

    [HttpGet("Frontend")]
    public async Task<List<SkillDTO>> GetFrontend() => await _repo.GetFrontend();
}
