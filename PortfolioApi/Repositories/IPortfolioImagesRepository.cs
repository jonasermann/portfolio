using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IPortfolioImagesRepository
{
    public byte[] Get(int id);
}
