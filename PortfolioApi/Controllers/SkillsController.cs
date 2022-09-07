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
    public List<SkillDTO> GetBackend() => _repo.GetBackend();

    [HttpGet("Frontend")]
    public List<SkillDTO> GetFrontend() => _repo.GetFrontend();
}
