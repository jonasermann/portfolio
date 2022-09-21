using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IHomeRepository
{
    public Task<HomeContentDTO> GetHomeContent();

    public Task<HomeContentDTO> PutHomeContent(HomeContentDTO homeContentDTO);

    public Task<List<HomeLinkDTO>> GetHomeLinks();

    public Task<HomeLinkDTO> GetHomeLink(int id);

    public Task<HomeLinkDTO> AddHomeLink(HomeLinkCreateDTO homeLinkCreateDTO);

    public Task<HomeLinkDTO> PutHomeLink(HomeLinkDTO homeLinkDTO);

    public Task DeleteHomeLink(int id);
}
