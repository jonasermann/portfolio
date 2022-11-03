using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IProjectsRepository
{
    public List<ProjectDTO> Get();

    public Task<ProjectDTO> Get(int id);

    public Task<ProjectDTO> Add(ProjectCreateDTO projectCreateDTO);

    public Task<ProjectDTO> Put(ProjectDTO projectDTO);

    public Task Delete(int id);
}
