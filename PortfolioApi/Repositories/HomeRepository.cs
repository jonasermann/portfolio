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

    public async Task<HomeContentDTO> GetHomeContent()
    {
        if (_context.HomeContent == null) return new HomeContentDTO 
        {
            Text = "Something went wrong... please try again later!"
        };

        var obj = await _context.HomeContent.FirstOrDefaultAsync();

        var dto = new HomeContentDTO
        {
            ProfilePicUrl = obj.ProfilePicUrl,
            Text = obj.Text
        };

        return dto;
    }

    public async Task<List<HomeHistoryDTO>> GetHomeHistory()
    {
        if (_context.HomeHistory == null) return new List<HomeHistoryDTO>
        {
            new HomeHistoryDTO 
            {
                Text = "Something went wrong... please try again later!"
            }
        };

        var objs = await _context.HomeHistory.ToListAsync();

        var dtos = objs.Select(h => new HomeHistoryDTO
        {
            Text = h.Text
        }).ToList();

        return dtos;
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

        var obj = await _context.HomeLinks.ToListAsync();

        var dtos = obj.Select(h => new HomeLinkDTO
        {
            ImgUrl = h.ImgUrl,
            Url = h.Url,
            Text = h.Text
        }).ToList();

        return dtos;
    }
}
