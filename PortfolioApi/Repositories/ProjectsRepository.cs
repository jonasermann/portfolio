using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class ProjectsRepository : IProjectsRepository
{
    private PortfolioAppContext _context;

    public ProjectsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectDTO>> Get()
    {
        if (_context.Projects == null) return new List<ProjectDTO>() {
            new ProjectDTO
            {
                Text = "Something went wrong.. Please try again later!"
            }
        };

        var objs = await _context.Projects.ToListAsync();

        var dtos = objs.Select(p => new ProjectDTO
        {
            Title = p.Title,
            ImgUrl = p.ImgUrl,
            Text = p.Text,
            GitUrl = p.GitUrl
        }).ToList();

        return dtos;
    }
}
