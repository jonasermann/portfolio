using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public class SkillsRepository : ISkillsRepository
{
    private PortfolioAppContext _context;

    public SkillsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public List<SkillDTO> GetBackend()
    {
        var objs = _context.Skills.Where(s => s.Type == 0).ToList();

        var dtos = objs.Select(c => new SkillDTO
        {
            ImgUrl = c.ImgUrl,
            Text = c.Text
        }).ToList();

        return dtos;
    }

    public List<SkillDTO> GetFrontend()
    {
        var objs = _context.Skills.Where(s => s.Type == 1).ToList();

        var dtos = objs.Select(c => new SkillDTO
        {
            ImgUrl = c.ImgUrl,
            Text = c.Text
        }).ToList();

        return dtos;
    }
}

