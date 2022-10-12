using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Repositories;
using PortfolioApi.Models;
using Microsoft.AspNetCore.Authorization;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private ISkillsRepository _repo;
    public SkillsController(ISkillsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("Backend"), AllowAnonymous]
    public async Task<List<SkillDTO>> GetBackend() => await _repo.GetBackend();

    [HttpGet("Frontend"), AllowAnonymous]
    public async Task<List<SkillDTO>> GetFrontend() => await _repo.GetFrontend();

    [HttpGet("Languages"), AllowAnonymous]
    public async Task<List<SkillDTO>> GetLanguages() => await _repo.GetLanguages();

    [HttpGet, AllowAnonymous]
    public async Task<List<SkillDTO>> Get() => await _repo.Get();

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<SkillDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<SkillDTO> Add(SkillCreateDTO skillCreateDTO) => await _repo.Add(skillCreateDTO);

    [HttpPut]
    public async Task<SkillDTO> Put(SkillDTO skillDTO) => await _repo.Put(skillDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
