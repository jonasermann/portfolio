using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IContactsRepository
{
    public List<ContactDTO> Get();
}
