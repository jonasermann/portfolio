using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IContactsRepository
{
    public Task<List<ContactDTO>> Get();
}
