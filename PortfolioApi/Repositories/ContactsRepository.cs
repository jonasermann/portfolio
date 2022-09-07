using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public class ContactsRepository : IContactsRepository
{
    private PortfolioAppContext _context;

    public ContactsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public List<ContactDTO> Get()
    {
        var objs = _context.Contacts.ToList();

        var dtos = objs.Select(c => new ContactDTO
        {
            ImgUrl = c.ImgUrl,
            Text = c.Text
        }).ToList();

        return dtos;
    }
}
