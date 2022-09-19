using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private IProjectsRepository _repo;

    public ProjectsController(IProjectsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<List<ProjectDTO>> Get() => await _repo.Get();

    [HttpGet("{id}")]
    public async Task<ProjectDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<ProjectDTO> Add(ProjectDTO projectDTO) => await _repo.Add(projectDTO);

    [HttpPut]
    public async Task<Project> Put(Project project) => await _repo.Put(project);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
