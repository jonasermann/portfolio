using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IProjectsRepository
{
    public Task<List<ProjectDTO>> Get();
}
