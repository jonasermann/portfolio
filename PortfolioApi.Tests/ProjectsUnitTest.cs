using Xunit;
using PortfolioApi.Models;
using PortfolioApi.Repositories;
using PortfolioApi.Data;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace PortfolioApiTests;

public class ProjectsUnitTest
{
    private readonly ProjectsRepository _repo;

    private readonly PortfolioAppContext _context;

    private readonly Project FirstProject = new ()
    {
        Id = 1,
        Title = "Title 1",
        ImgUrl = "ImgUrl 1",
        Text = "Text 1",
        GitUrl = "GitUrl 1"
    };

    private readonly Project SecondProject = new ()
    {
        Id = 2,
        Title = "Title 2",
        ImgUrl = "ImgUrl 2",
        Text = "Text 2",
        GitUrl = "GitUrl 2"
    };

    private readonly ProjectDTO FirstProjectDTO = new ()
    {
        Id = 1,
        Title = "Title 1",
        ImgUrl = "ImgUrl 1",
        Text = "Text 1",
        GitUrl = "GitUrl 1"
    };

    public ProjectsUnitTest()
    {
        var contextOptions = new DbContextOptionsBuilder<PortfolioAppContext>()
            .UseInMemoryDatabase("Filename=:memory:")
            .Options;

        _context = new PortfolioAppContext(contextOptions);

        _context.Database.EnsureCreated();
        _context.AddRange(FirstProject, SecondProject);
        _context.SaveChanges();

        _repo = new ProjectsRepository(_context);
    }

    [Fact]
    public void ConvertsProjectToProjectDTO()
    {
        var projectDTO = ProjectsRepository.ConvertToProjectDTO(FirstProject);
        projectDTO.Should().BeEquivalentTo(FirstProjectDTO);
    }

    [Fact]
    public void ConvertsProjectDTOToProject()
    {
        var project = ProjectsRepository.ConvertToProject(FirstProjectDTO);
        project.Should().BeEquivalentTo(FirstProject);
    }

    [Fact]
    public void GetsAllProjects()
    {
        var projectDTOs = _repo.Get();
        projectDTOs.Should().HaveCount(2);
    }

    [Fact]
    public async void GetsProjectById()
    {
        var projectDTO = await _repo.Get(1);
        projectDTO.Should().BeEquivalentTo(FirstProjectDTO);
    }

    [Fact]
    public async void AddsNewProject()
    {
        var projectCreateDTO = new ProjectCreateDTO
        {
            Title = "Title 3",
            ImgUrl = "ImgUrl 3",
            Text = "Text 3",
            GitUrl = "GitUrl 3"
        };

        var project = new Project
        {
            Id = 3,
            Title = "Title 3",
            ImgUrl = "ImgUrl 3",
            Text = "Text 3",
            GitUrl = "GitUrl 3"
        };

        await _repo.Add(projectCreateDTO);

        var createdProject = _context.Projects.FirstOrDefault(p => p.Id == 3);

        createdProject.Should().BeEquivalentTo(project);
    }

    [Fact]
    public async void RemovesProject()
    {
        await _repo.Delete(2);

        var projects = _context.Projects;

        projects.Where(p => p.Id == 2).Should().BeNullOrEmpty();
    }
}
