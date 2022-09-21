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

    [HttpGet("Languages")]
    public async Task<List<SkillDTO>> GetLanguages() => await _repo.GetLanguages();

    [HttpGet]
    public async Task<List<SkillDTO>> Get() => await _repo.Get();

    [HttpGet("{id}")]
    public async Task<SkillDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<SkillDTO> Add(SkillCreateDTO skillCreateDTO) => await _repo.Add(skillCreateDTO);

    [HttpPut]
    public async Task<SkillDTO> Put(SkillDTO skillDTO) => await _repo.Put(skillDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
