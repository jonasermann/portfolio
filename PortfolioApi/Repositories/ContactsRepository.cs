using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class ContactsRepository : IContactsRepository
{
    private PortfolioAppContext _context;

    public ContactsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public async Task<List<ContactDTO>> Get()
    {
        if(_context.Contacts == null) return new List<ContactDTO> { 
            new ContactDTO
            { 
                Text = "Something went wrong... please try again later!" 
            } 
        };

        var objs = await _context.Contacts.ToListAsync();

        var dtos = objs.Select(c => new ContactDTO
        {
            ImgUrl = c.ImgUrl,
            Text = c.Text
        }).ToList();

        return dtos;
    }
}
