using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectsRepository _repo;

    public ProjectsController(IProjectsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet, AllowAnonymous]
    public List<ProjectDTO> Get() => _repo.Get();

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<ProjectDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<ProjectDTO> Add(ProjectCreateDTO projectCreateDTO) => await _repo.Add(projectCreateDTO);

    [HttpPut]
    public async Task<ProjectDTO> Put(ProjectDTO projectDTO) => await _repo.Put(projectDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
