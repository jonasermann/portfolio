using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IPortfolioImagesRepository
{
    public Task<byte[]> Get(int id);
}
