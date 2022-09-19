using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IHomeRepository
{
    public Task<HomeContentDTO> GetHomeContent();

    public Task<List<HomeHistoryDTO>> GetHomeHistory();

    public Task<List<HomeLinkDTO>> GetHomeLinks();
}
