using Xunit;
using PortfolioApi.Models;
using PortfolioApi.Repositories;
using PortfolioApi.Data;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace PortfolioApiTests;

public class BackgroundParagraphsUnitTest
{
    private readonly BackgroundParagraphsRepository _repo;

    private readonly PortfolioAppContext _context;

    private readonly BackgroundParagraph FirstBackgroundParagraph = new()
    {
        Id = 1,
        Text = "Text 1"
    };

    private readonly BackgroundParagraph SecondBackgroundParagraph = new()
    {
        Id = 2,
        Text = "Text 2"
    };

    private readonly BackgroundParagraphDTO FirstBackgroundParagraphDTO = new()
    {
        Id = 1,
        Text = "Text 1"
    };

    public BackgroundParagraphsUnitTest()
    {
        var contextOptions = new DbContextOptionsBuilder<PortfolioAppContext>()
            .UseInMemoryDatabase("Filename=:memory:")
            .Options;

        _context = new PortfolioAppContext(contextOptions);

        _context.Database.EnsureCreated();
        _context.AddRange(FirstBackgroundParagraph, SecondBackgroundParagraph);
        _context.SaveChanges();

        _repo = new BackgroundParagraphsRepository(_context);
    }

    [Fact]
    public void ConvertsBackgroundParagraphToBackgroundParagraphDTO()
    {
        var backgroundParagraphDTO = BackgroundParagraphsRepository.ConvertToBackgroundParagraphDTO(FirstBackgroundParagraph);
        backgroundParagraphDTO.Should().BeEquivalentTo(FirstBackgroundParagraphDTO);
    }

    [Fact]
    public void ConvertsBackgroundParagraphDTOToBackgroundParagraph()
    {
        var backgroundParagraph = BackgroundParagraphsRepository.ConvertToBackgroundParagraph(FirstBackgroundParagraphDTO);
        backgroundParagraph.Should().BeEquivalentTo(FirstBackgroundParagraph);
    }

    [Fact]
    public void GetsAllBackgroundParagraphs()
    {
        var backgroundParagraphDTOs = _repo.Get();
        backgroundParagraphDTOs.Should().HaveCount(2);
    }

    [Fact]
    public async void GetsBackgroundParagraphById()
    {
        var backgroundParagraphDTO = await _repo.Get(1);
        backgroundParagraphDTO.Should().BeEquivalentTo(FirstBackgroundParagraphDTO);
    }

    [Fact]
    public async void AddsNewBackgroundParagraph()
    {
        var backgroundParagraphCreateDTO = new BackgroundParagraphCreateDTO
        {
            Text = "Text 3"
        };

        var backgroundParagraph = new BackgroundParagraph
        {
            Id = 3,
            Text = "Text 3"
        };

        await _repo.Add(backgroundParagraphCreateDTO);

        var createdBackgroundParagraph = _context.BackgroundParagraphs.FirstOrDefault(p => p.Id == 3);

        createdBackgroundParagraph.Should().BeEquivalentTo(backgroundParagraph);
    }

    [Fact]
    public async void RemovesBackgroundParagraph()
    {
        await _repo.Delete(2);

        var backgroundParagraphs = _context.BackgroundParagraphs;

        backgroundParagraphs.Where(p => p.Id == 2).Should().BeNullOrEmpty();
    }
}
