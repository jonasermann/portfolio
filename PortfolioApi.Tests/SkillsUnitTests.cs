using Xunit;
using PortfolioApi.Models;
using PortfolioApi.Repositories;
using PortfolioApi.Data;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace PortfolioApiTests;

public class SkillsUnitTest
{
    private readonly SkillsRepository _repo;

    private readonly PortfolioAppContext _context;

    private readonly Skill FirstSkill = new()
    {
        Id = 1,
        ImgUrl = "ImgUrl 1",
        Text = "Text 1"
    };

    private readonly Skill SecondSkill = new()
    {
        Id = 2,
        ImgUrl = "ImgUrl 2",
        Text = "Text 2"
    };

    private readonly SkillDTO FirstSkillDTO = new()
    {
        Id = 1,
        ImgUrl = "ImgUrl 1",
        Text = "Text 1"
    };

    public SkillsUnitTest()
    {
        var contextOptions = new DbContextOptionsBuilder<PortfolioAppContext>()
            .UseInMemoryDatabase("Filename=:memory:")
            .Options;

        _context = new PortfolioAppContext(contextOptions);

        _context.Database.EnsureCreated();
        _context.AddRange(FirstSkill, SecondSkill);
        _context.SaveChanges();

        _repo = new SkillsRepository(_context);
    }

    [Fact]
    public void ConvertsSkillToSkillDTO()
    {
        var skillDTO = SkillsRepository.ConvertToSkillDTO(FirstSkill);
        skillDTO.Should().BeEquivalentTo(FirstSkillDTO);
    }

    [Fact]
    public void ConvertsSkillDTOToSkill()
    {
        var skill = SkillsRepository.ConvertToSkill(FirstSkillDTO);
        skill.Should().BeEquivalentTo(FirstSkill);
    }

    [Fact]
    public void GetsAllSkills()
    {
        var skillDTOs = _repo.Get();
        skillDTOs.Should().HaveCount(2);
    }

    [Fact]
    public async void GetsSkillById()
    {
        var skillDTO = await _repo.Get(1);
        skillDTO.Should().BeEquivalentTo(FirstSkillDTO);
    }

    [Fact]
    public async void AddsNewSkill()
    {
        var skillCreateDTO = new SkillCreateDTO
        {
            ImgUrl = "ImgUrl 3",
            Text = "Text 3"
        };

        var skill = new Skill
        {
            Id = 3,
            ImgUrl = "ImgUrl 3",
            Text = "Text 3"
        };

        await _repo.Add(skillCreateDTO);

        var createdSkill = _context.Skills.FirstOrDefault(p => p.Id == 3);

        createdSkill.Should().BeEquivalentTo(skill);
    }

    [Fact]
    public async void RemovesSkill()
    {
        await _repo.Delete(2);

        var skills = _context.Skills;

        skills.Where(p => p.Id == 2).Should().BeNullOrEmpty();
    }
}
