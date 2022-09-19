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

    public ProjectDTO ConvertToProjectDTO(Project project)
    {
        return new ProjectDTO
        {
            Title = project.Title,
            ImgUrl = project.ImgUrl,
            Text = project.Text,
            GitUrl = project.GitUrl
        };
    }

    public Project ConvertToProject(ProjectDTO projectDTO, int id)
    {
        return new Project
        {
            Id = id,
            Title = projectDTO.Title,
            ImgUrl = projectDTO.ImgUrl,
            Text = projectDTO.Text,
            GitUrl = projectDTO.GitUrl
        };
    }

    public ProjectDTO EmptyProjectDTO()
    {
        return new ProjectDTO
        {
            Text = "Something went wrong.. Please try again later!"
        };
    }

    public async Task<List<ProjectDTO>> Get()
    {
        if (_context.Projects == null) return new List<ProjectDTO>() { EmptyProjectDTO() };
        var projects = await _context.Projects.ToListAsync();

        var dtos = projects.Select(p => ConvertToProjectDTO(p)).ToList();
        return dtos;
    }

    public async Task<ProjectDTO> Get(int id)
    {
        if (_context.Projects == null) return EmptyProjectDTO();
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

        if (project == null) return EmptyProjectDTO();
        return ConvertToProjectDTO(project);
    }

    public async Task<ProjectDTO> Add(ProjectDTO projectDTO)
    {
        if (_context.Projects == null) return EmptyProjectDTO();
        int id = await _context.Projects.MaxAsync(p => p.Id);

        await _context.Projects.AddAsync(ConvertToProject(projectDTO, id + 1));
        await _context.SaveChangesAsync();
        return projectDTO;
    }

    public async Task<Project> Put(Project project)
    {
        if (_context.Projects == null) throw new Exception("Database Empty.");
        _context.Projects.Update(project);

        await _context.SaveChangesAsync();
        return project;
    }

    public async Task Delete(int id)
    {
        if (_context.Projects == null) return;
        var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

        if (project == null) return;
        _context.Remove(project);

        await _context.SaveChangesAsync();
    }
}
