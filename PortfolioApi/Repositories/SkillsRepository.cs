using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class SkillsRepository : ISkillsRepository
{
    private PortfolioAppContext _context;

    public SkillsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public async Task<List<SkillDTO>> GetSkills(int identifier)
    {
        if (_context.Skills == null) return new List<SkillDTO>()
        {
            new SkillDTO
            {
                Text = "Something went wrong... Please try again later!"
            }
        };

        var objs = await _context.Skills.ToListAsync();

        var dtos = objs.Where(s => s.Type == identifier).Select(c => new SkillDTO
        {
            ImgUrl = c.ImgUrl,
            Text = c.Text
        }).ToList();

        return dtos;
    }

    public async Task<List<SkillDTO>> GetBackend() => await GetSkills(0);

    public async Task<List<SkillDTO>> GetFrontend() => await GetSkills(1);
}
