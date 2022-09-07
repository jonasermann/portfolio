using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface ISkillsRepository
{
    public List<SkillDTO> GetBackend();

    public List<SkillDTO> GetFrontend();
}
