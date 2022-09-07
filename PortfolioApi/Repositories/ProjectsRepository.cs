using PortfolioApi.Data;
using PortfolioApi.Models;
using System.Data.Entity;

namespace PortfolioApi.Repositories;

public class ProjectsRepository : IProjectsRepository
{
    private PortfolioAppContext _context;

    public ProjectsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public List<ProjectDTO> Get()
    {
        var objs = _context.Projects.ToList();

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
