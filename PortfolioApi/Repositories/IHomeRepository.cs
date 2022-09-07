using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IHomeRepository
{
    public HomeContentDTO GetHomeContent();

    public List<HomeHistoryDTO> GetHomeHistory();

    public List<HomeLinksDTO> GetHomeLinks();
}
