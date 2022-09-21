using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class HomeRepository : IHomeRepository
{
    private PortfolioAppContext _context;

    public HomeRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public HomeContentDTO ConvertToHomeContentDTO(HomeContent homeContent) => new HomeContentDTO
    {
        Id = homeContent.Id,
        Text = homeContent.Text
    };

    public HomeContent ConvertToHomeContent(HomeContentDTO homeContentDTO) => new HomeContent
    {
        Id = homeContentDTO.Id,
        Text = homeContentDTO.Text
    };

    public HomeContentDTO EmptyHomeContentDTO() => new HomeContentDTO { };

    public async Task<HomeContentDTO> GetHomeContent()
    {
        if (_context.HomeContent == null) return EmptyHomeContentDTO();
        var homeContent = await _context.HomeContent.FirstOrDefaultAsync();

        if (homeContent == null) return EmptyHomeContentDTO();
        return ConvertToHomeContentDTO(homeContent);
    }

    public async Task<HomeContentDTO> PutHomeContent(HomeContentDTO homeContentDTO)
    {
        if (_context.HomeContent == null) throw new Exception("Database Empty.");
        var updatedHomeContent = ConvertToHomeContent(homeContentDTO);

        _context.HomeContent.Update(updatedHomeContent);
        await _context.SaveChangesAsync();

        return homeContentDTO;
    }



    public HomeLinkDTO ConvertToHomeLinkDTO(HomeLink homeLink) => new HomeLinkDTO
    {
        Id = homeLink.Id,
        ImgUrl = homeLink.ImgUrl,
        Text = homeLink.Text
    };

    public HomeLink ConvertToHomeLink(HomeLinkDTO homeLinkDTO) => new HomeLink
    {
        Id = homeLinkDTO.Id,
        ImgUrl = homeLinkDTO.ImgUrl,
        Text = homeLinkDTO.Text
    };

    public HomeLinkDTO EmptyHomeLinkDTO() => new HomeLinkDTO { };

    public async Task<List<HomeLinkDTO>> GetHomeLinks()
    {
        if (_context.HomeLinks == null) return new List<HomeLinkDTO>() { };
        var homeLinks = await _context.HomeLinks.ToListAsync();

        var homeLinkDTOs = homeLinks.Select(p => ConvertToHomeLinkDTO(p)).ToList();
        return homeLinkDTOs;
    }

    public async Task<HomeLinkDTO> GetHomeLink(int id)
    {
        if (_context.HomeLinks == null) return EmptyHomeLinkDTO();
        var homeLink = await _context.HomeLinks.FirstOrDefaultAsync(p => p.Id == id);

        if (homeLink == null) return EmptyHomeLinkDTO();
        return ConvertToHomeLinkDTO(homeLink);
    }

    public async Task<HomeLinkDTO> AddHomeLink(HomeLinkCreateDTO homeLinkCreateDTO)
    {
        int id;
        if (_context.HomeLinks == null) id = 0;
        else id = await _context.HomeLinks.MaxAsync(p => p.Id);

        var newHomeLink = new HomeLink
        {
            Id = id + 1,
            ImgUrl = homeLinkCreateDTO.ImgUrl,
            Text = homeLinkCreateDTO.Text
        };

        if (_context.HomeLinks == null) return EmptyHomeLinkDTO();
        await _context.HomeLinks.AddAsync(newHomeLink);
        await _context.SaveChangesAsync();

        return ConvertToHomeLinkDTO(newHomeLink);
    }

    public async Task<HomeLinkDTO> PutHomeLink(HomeLinkDTO homeLinkDTO)
    {
        if (_context.HomeLinks == null) throw new Exception("Database Empty.");
        var updatedHomeLink = ConvertToHomeLink(homeLinkDTO);

        _context.HomeLinks.Update(updatedHomeLink);
        await _context.SaveChangesAsync();

        return homeLinkDTO;
    }

    public async Task DeleteHomeLink(int id)
    {
        if (_context.HomeLinks == null) return;
        var homeLink = await _context.HomeLinks.FirstOrDefaultAsync(p => p.Id == id);

        if (homeLink == null) return;
        _context.Remove(homeLink);
        await _context.SaveChangesAsync();
    }
}
