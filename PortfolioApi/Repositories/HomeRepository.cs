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

    public HomeContent ConvertToHomeContent(HomeContentDTO homeContentDTO) => new HomeContent
    {
        Id = homeContentDTO.Id,
        ProfilePicUrl = homeContentDTO.ProfilePicUrl,
        Text = homeContentDTO.Text
    };

    public HomeContentDTO ConvertToHomeContentDTO(HomeContent homeContent) => new HomeContentDTO
    {
        Id = homeContent.Id,
        ProfilePicUrl = homeContent.ProfilePicUrl,
        Text = homeContent.Text
    };

    public HomeContent EmptyHomeContent() => new HomeContent
    {
        Text = "Something went wrong... please try again later!"
    };

    public HomeContentDTO EmptyHomeContentDTO() => new HomeContentDTO
    {
        Text = "Something went wrong... please try again later!"
    };

    public async Task<HomeContentDTO> GetHomeContent()
    {
        if (_context.HomeContent == null) return EmptyHomeContentDTO();
        var homeContent = await _context.HomeContent.FirstOrDefaultAsync();

        if (homeContent == null) return EmptyHomeContentDTO();

        return ConvertToHomeContentDTO(homeContent);
    }

    public async Task<List<HomeHistoryDTO>> GetHomeHistory()
    {
        if (_context.HomeHistory == null) return new List<HomeHistoryDTO>() { };

        var homeHistories = await _context.HomeHistory.ToListAsync();

        var homeHIstoryDTOs = homeHistories.Select(h => new HomeHistoryDTO
        {
            Text = h.Text
        }).ToList();

        return homeHIstoryDTOs;
    }

    public async Task<List<HomeLinkDTO>> GetHomeLinks()
    {
        if (_context.HomeLinks == null) return new List<HomeLinkDTO>
        {
            new HomeLinkDTO
            {
                Text = "Something went wrong... please try again later!"
            }
        };

        var homeLinks = await _context.HomeLinks.ToListAsync();

        var homeLinkDTOs = homeLinks.Select(h => new HomeLinkDTO
        {
            ImgUrl = h.ImgUrl,
            Url = h.Url,
            Text = h.Text
        }).ToList();

        return homeLinkDTOs;
    }
}
