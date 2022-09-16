using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface ISkillsRepository
{
    public Task<List<SkillDTO>> GetSkills(int identifier);

    public Task<List<SkillDTO>> GetBackend();

    public Task<List<SkillDTO>> GetFrontend();
}
