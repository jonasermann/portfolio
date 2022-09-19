using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IProjectsRepository
{
    public Task<List<ProjectDTO>> Get();

    public Task<ProjectDTO> Get(int id);

    public Task<ProjectDTO> Add(ProjectDTO projectDTO);

    public Task<Project> Put(Project project);

    public Task Delete(int id);
}
