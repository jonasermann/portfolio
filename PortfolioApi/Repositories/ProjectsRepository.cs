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

    public ProjectDTO ConvertToProjectDTO(Project project) =>  new ProjectDTO
    {
        Id = project.Id,
        Title = project.Title,
        ImgUrl = project.ImgUrl,
        Text = project.Text,
        GitUrl = project.GitUrl
    };

    public Project ConvertToProject(ProjectDTO projectDTO) => new Project
    {
        Id = projectDTO.Id,
        Title = projectDTO.Title,
        ImgUrl = projectDTO.ImgUrl,
        Text = projectDTO.Text,
        GitUrl = projectDTO.GitUrl
    };

    public ProjectDTO EmptyProjectDTO() => new ProjectDTO { };

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

    public async Task<ProjectDTO> Add(ProjectCreateDTO projectCreateDTO)
    {
        int id;
        if (_context.Projects == null) id = 0;
        else id = await _context.Projects.MaxAsync(p => p.Id);

        var newProject = new Project
        {
            Id = id + 1,
            Title = projectCreateDTO.Title,
            ImgUrl = projectCreateDTO.ImgUrl,
            Text = projectCreateDTO.Text,
            GitUrl = projectCreateDTO.GitUrl,
        };

        if (_context.Projects == null) return EmptyProjectDTO();
        await _context.Projects.AddAsync(newProject);
        await _context.SaveChangesAsync();
        return ConvertToProjectDTO(newProject);
    }

    public async Task<ProjectDTO> Put(ProjectDTO projectDTO)
    {
        if (_context.Projects == null) throw new Exception("Database Empty.");
        var updatedProject = ConvertToProject(projectDTO);
        _context.Projects.Update(updatedProject);

        await _context.SaveChangesAsync();
        return projectDTO;
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
