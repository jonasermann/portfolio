using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IIntroductionRepository
{
    public Task<IntroductionDTO> Get();

    public Task<IntroductionDTO> Put(IntroductionDTO introductionDTO);

}
