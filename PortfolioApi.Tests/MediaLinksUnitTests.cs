using Xunit;
using PortfolioApi.Models;
using PortfolioApi.Repositories;
using PortfolioApi.Data;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace PortfolioApiTests;

public class MediaLinksUnitTest
{
    private readonly MediaLinksRepository _repo;

    private readonly PortfolioAppContext _context;

    private readonly MediaLink FirstMediaLink = new()
    {
        Id = 1,
        ImgUrl = "ImgUrl 1",
        Text = "Text 1"
    };

    private readonly MediaLink SecondMediaLink = new()
    {
        Id = 2,
        ImgUrl = "ImgUrl 2",
        Text = "Text 2"
    };

    private readonly MediaLinkDTO FirstMediaLinkDTO = new()
    {
        Id = 1,
        ImgUrl = "ImgUrl 1",
        Text = "Text 1"
    };

    public MediaLinksUnitTest()
    {
        var contextOptions = new DbContextOptionsBuilder<PortfolioAppContext>()
            .UseInMemoryDatabase("Filename=:memory:")
            .Options;

        _context = new PortfolioAppContext(contextOptions);

        _context.Database.EnsureCreated();
        _context.AddRange(FirstMediaLink, SecondMediaLink);
        _context.SaveChanges();

        _repo = new MediaLinksRepository(_context);
    }

    [Fact]
    public void ConvertsMediaLinkToMediaLinkDTO()
    {
        var mediaLinkDTO = MediaLinksRepository.ConvertToMediaLinkDTO(FirstMediaLink);
        mediaLinkDTO.Should().BeEquivalentTo(FirstMediaLinkDTO);
    }

    [Fact]
    public void ConvertsMediaLinkDTOToMediaLink()
    {
        var mediaLink = MediaLinksRepository.ConvertToMediaLink(FirstMediaLinkDTO);
        mediaLink.Should().BeEquivalentTo(FirstMediaLink);
    }

    [Fact]
    public void GetsAllMediaLinks()
    {
        var mediaLinkDTOs = _repo.Get();
        mediaLinkDTOs.Should().HaveCount(2);
    }

    [Fact]
    public async void GetsMediaLinkById()
    {
        var mediaLinkDTO = await _repo.Get(1);
        mediaLinkDTO.Should().BeEquivalentTo(FirstMediaLinkDTO);
    }

    [Fact]
    public async void AddsNewMediaLink()
    {
        var mediaLinkCreateDTO = new MediaLinkCreateDTO
        {
            ImgUrl = "ImgUrl 3",
            Text = "Text 3"
        };

        var mediaLink = new MediaLink
        {
            Id = 3,
            ImgUrl = "ImgUrl 3",
            Text = "Text 3"
        };

        await _repo.Add(mediaLinkCreateDTO);

        var createdMediaLink = _context.MediaLinks.FirstOrDefault(p => p.Id == 3);

        createdMediaLink.Should().BeEquivalentTo(mediaLink);
    }

    [Fact]
    public async void RemovesMediaLink()
    {
        await _repo.Delete(2);

        var mediaLinks = _context.MediaLinks;

        mediaLinks.Where(p => p.Id == 2).Should().BeNullOrEmpty();
    }
}
