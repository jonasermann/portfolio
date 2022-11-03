using Xunit;
using PortfolioApi.Models;
using PortfolioApi.Repositories;
using PortfolioApi.Data;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace PortfolioApiTests;

public class ContactsUnitTest
{
    private readonly ContactsRepository _repo;

    private readonly PortfolioAppContext _context;

    private readonly Contact FirstContact = new()
    {
        Id = 1,
        ImgUrl = "ImgUrl 1",
        Text = "Text 1"
    };

    private readonly Contact SecondContact = new()
    {
        Id = 2,
        ImgUrl = "ImgUrl 2",
        Text = "Text 2"
    };

    private readonly ContactDTO FirstContactDTO = new()
    {
        Id = 1,
        ImgUrl = "ImgUrl 1",
        Text = "Text 1",
    };

    public ContactsUnitTest()
    {
        var contextOptions = new DbContextOptionsBuilder<PortfolioAppContext>()
            .UseInMemoryDatabase("Filename=:memory:")
            .Options;

        _context = new PortfolioAppContext(contextOptions);

        _context.Database.EnsureCreated();
        _context.AddRange(FirstContact, SecondContact);
        _context.SaveChanges();

        _repo = new ContactsRepository(_context);
    }

    [Fact]
    public void ConvertsContactToContactDTO()
    {
        var contactDTO = ContactsRepository.ConvertToContactDTO(FirstContact);
        contactDTO.Should().BeEquivalentTo(FirstContactDTO);
    }

    [Fact]
    public void ConvertsContactDTOToContact()
    {
        var contact = ContactsRepository.ConvertToContact(FirstContactDTO);
        contact.Should().BeEquivalentTo(FirstContact);
    }

    [Fact]
    public void GetsAllContacts()
    {
        var contactDTOs = _repo.Get();
        contactDTOs.Should().HaveCount(2);
    }

    [Fact]
    public async void GetsContactById()
    {
        var contactDTO = await _repo.Get(1);
        contactDTO.Should().BeEquivalentTo(FirstContactDTO);
    }

    [Fact]
    public async void AddsNewContact()
    {
        var contactCreateDTO = new ContactCreateDTO
        {
            ImgUrl = "ImgUrl 3",
            Text = "Text 3"
        };

        var contact = new Contact
        {
            Id = 3,
            ImgUrl = "ImgUrl 3",
            Text = "Text 3"
        };

        await _repo.Add(contactCreateDTO);

        var createdContact = _context.Contacts.FirstOrDefault(p => p.Id == 3);

        createdContact.Should().BeEquivalentTo(contact);
    }

    [Fact]
    public async void RemovesContact()
    {
        await _repo.Delete(2);

        var contacts = _context.Contacts;

        contacts.Where(p => p.Id == 2).Should().BeNullOrEmpty();
    }
}
