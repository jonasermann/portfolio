using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class ContactsRepository : IContactsRepository
{
    private readonly PortfolioAppContext _context;

    public ContactsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public static ContactDTO ConvertToContactDTO(Contact Contact) => new ()
    {
        Id = Contact.Id,
        ImgUrl = Contact.ImgUrl,
        Text = Contact.Text
    };

    public static Contact ConvertToContact(ContactDTO ContactDTO) => new ()
    {
        Id = ContactDTO.Id,
        ImgUrl = ContactDTO.ImgUrl,
        Text = ContactDTO.Text
    };

    public ContactDTO EmptyContactDTO() => new ContactDTO { };

    public List<ContactDTO> Get()
    {
        if (_context.Contacts == null) return new List<ContactDTO>() { };
        var contacts = _context.Contacts;

        var contactDTOs = contacts.Select(p => ConvertToContactDTO(p)).ToList();
        return contactDTOs;
    }

    public async Task<ContactDTO> Get(int id)
    {
        if (_context.Contacts == null) return EmptyContactDTO();
        var contact = await _context.Contacts.FirstOrDefaultAsync(p => p.Id == id);

        if (contact == null) return EmptyContactDTO();
        return ConvertToContactDTO(contact);
    }

    public async Task<ContactDTO> Add(ContactCreateDTO contactCreateDTO)
    {
        int id;
        if (_context.Contacts == null) id = 0;
        else id = await _context.Contacts.MaxAsync(p => p.Id);

        var newContact = new Contact
        {
            Id = id + 1,
            ImgUrl = contactCreateDTO.ImgUrl,
            Text = contactCreateDTO.Text
        };

        if (_context.Contacts == null) return EmptyContactDTO();
        await _context.Contacts.AddAsync(newContact);
        await _context.SaveChangesAsync();

        return ConvertToContactDTO(newContact);
    }

    public async Task<ContactDTO> Put(ContactDTO contactDTO)
    {
        if (_context.Contacts == null) throw new Exception("Database Empty.");
        var updatedContact = ConvertToContact(contactDTO);

        _context.Contacts.Update(updatedContact);
        await _context.SaveChangesAsync();

        return contactDTO;
    }

    public async Task Delete(int id)
    {
        if (_context.Contacts == null) return;
        var contact = await _context.Contacts.FirstOrDefaultAsync(p => p.Id == id);

        if (contact == null) return;
        _context.Remove(contact);
        await _context.SaveChangesAsync();
    }
}
