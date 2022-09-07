using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IProjectsRepository
{
    public List<ProjectDTO> Get();
}
