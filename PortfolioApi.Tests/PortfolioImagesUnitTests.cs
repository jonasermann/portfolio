using Xunit;
using PortfolioApi.Models;
using PortfolioApi.Repositories;
using PortfolioApi.Data;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace PortfolioApiTests;

public class PortfolioImagesUnitTest
{
    private readonly PortfolioImagesRepository _repo;

    private readonly PortfolioAppContext _context;

    private readonly PortfolioImage FirstPortfolioImage = new()
    {
        Id = 1,
        ByteArray = new byte[] { 0x20 }
    };

    private readonly PortfolioImage SecondPortfolioImage = new()
    {
        Id = 2,
        ByteArray = new byte[] { 0x20, 0x20 }
    };

    private readonly PortfolioImageDTO FirstPortfolioImageDTO = new()
    {
        Id = 1,
        ByteArray = new byte[] { 0x20 }
    };

    public PortfolioImagesUnitTest()
    {
        var contextOptions = new DbContextOptionsBuilder<PortfolioAppContext>()
            .UseInMemoryDatabase("Filename=:memory:")
            .Options;

        _context = new PortfolioAppContext(contextOptions);

        _context.Database.EnsureCreated();
        _context.AddRange(FirstPortfolioImage, SecondPortfolioImage);
        _context.SaveChanges();

        _repo = new PortfolioImagesRepository(_context);
    }

    [Fact]
    public void ConvertsPortfolioImageToPortfolioImageDTO()
    {
        var portfolioImageDTO = PortfolioImagesRepository.ConvertToPortfolioImageDTO(FirstPortfolioImage);
        portfolioImageDTO.Should().BeEquivalentTo(FirstPortfolioImageDTO);
    }

    [Fact]
    public void ConvertsPortfolioImageDTOToPortfolioImage()
    {
        var portfolioImage = PortfolioImagesRepository.ConvertToPortfolioImage(FirstPortfolioImageDTO);
        portfolioImage.Should().BeEquivalentTo(FirstPortfolioImage);
    }

    [Fact]
    public async void GetsPortfolioImageById()
    {
        var portfolioImageDTOByteArray = await _repo.Get(1);
        portfolioImageDTOByteArray.Should().BeEquivalentTo(FirstPortfolioImageDTO.ByteArray);
    }

    [Fact]
    public async void AddsNewPortfolioImage()
    {
        var portfolioImageCreateDTO = new PortfolioImageCreateDTO
        {
            ByteArray = new byte[] { 0x20, 0x20, 0x20 }
        };

        var portfolioImage = new PortfolioImage
        {
            Id = 3,
            ByteArray = new byte[] { 0x20, 0x20, 0x20 }
        };

        await _repo.Add(portfolioImageCreateDTO);

        var createdPortfolioImage = _context.PortfolioImages.FirstOrDefault(p => p.Id == 3);

        createdPortfolioImage.Should().BeEquivalentTo(portfolioImage);
    }

    [Fact]
    public async void RemovesPortfolioImage()
    {
        await _repo.Delete(2);

        var portfolioImages = _context.PortfolioImages;

        portfolioImages.Where(p => p.Id == 2).Should().BeNullOrEmpty();
    }
}
