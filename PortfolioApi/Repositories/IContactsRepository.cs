using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IContactsRepository
{
    public Task<List<ContactDTO>> Get();

    public Task<ContactDTO> Get(int id);

    public Task<ContactDTO> Add(ContactCreateDTO ContactCreateDTO);

    public Task<ContactDTO> Put(ContactDTO ContactDTO);

    public Task Delete(int id);
}
