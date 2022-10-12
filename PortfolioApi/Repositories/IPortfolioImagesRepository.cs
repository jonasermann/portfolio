using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IPortfolioImagesRepository
{
    public Task<byte[]> Get(int id);

    public Task<PortfolioImageDTO> Add(PortfolioImageCreateDTO portfolioImageCreateDTO);

    public Task<PortfolioImageDTO> Put(PortfolioImageDTO portfolioImageDTO);

    public Task Delete(int id);
}
