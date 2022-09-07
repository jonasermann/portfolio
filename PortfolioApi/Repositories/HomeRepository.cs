using PortfolioApi.Data;
using PortfolioApi.Models;
using System.Data.Entity;

namespace PortfolioApi.Repositories;

public class HomeRepository : IHomeRepository
{
    private PortfolioAppContext _context;

    public HomeRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public HomeContentDTO GetHomeContent()
    {
        var obj = _context.HomeContent.FirstOrDefault();

        var dto = new HomeContentDTO
        {
            ProfilePicUrl = obj.ProfilePicUrl,
            Text = obj.Text
        };

        return dto;
    }

    public List<HomeHistoryDTO> GetHomeHistory()
    {
        var objs = _context.HomeHistory.ToList();

        var dtos = objs.Select(h => new HomeHistoryDTO
        {
            Text = h.Text
        }).ToList();

        return dtos;
    }

    public List<HomeLinksDTO> GetHomeLinks()
    {
        var obj = _context.HomeLinks.ToList();

        var dtos = obj.Select(h => new HomeLinksDTO
        {
            ImgUrl = h.ImgUrl,
            Url = h.Url,
            Text = h.Text
        }).ToList();

        return dtos;
    }
}
