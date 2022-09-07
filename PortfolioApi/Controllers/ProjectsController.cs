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
    public List<ProjectDTO> Get() => _repo.Get();
}
