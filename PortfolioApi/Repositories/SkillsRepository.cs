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

    public SkillDTO ConvertToSkillDTO(Skill skill) => new SkillDTO
    {
        Id = skill.Id,
        ImgUrl = skill.ImgUrl,
        Text = skill.Text,
        Type = skill.Type
    };

    public Skill ConvertToSkill(SkillDTO skillDTO) => new Skill
    {
        Id = skillDTO.Id,
        ImgUrl = skillDTO.ImgUrl,
        Text = skillDTO.Text,
        Type = skillDTO.Type
    };

    public SkillDTO EmptySkillDTO() => new SkillDTO { };

    public Skill EmptySkill() => new Skill { };

    public async Task<List<SkillDTO>> GetSkills(int identifier)
    {
        if (_context.Skills == null) return new List<SkillDTO>() {};
        var skills = await _context.Skills.ToListAsync();

        var skillDTOs = skills.Where(s => s.Type == identifier).Select(s => ConvertToSkillDTO(s)).ToList();
        return skillDTOs;
    }

    public async Task<List<SkillDTO>> GetBackend() => await GetSkills(0);

    public async Task<List<SkillDTO>> GetFrontend() => await GetSkills(1);

    public async Task<List<SkillDTO>> GetLanguages() => await GetSkills(2);

    public async Task<List<SkillDTO>> Get()
    {
        if (_context.Skills == null) return new List<SkillDTO>() { };
        var skills = await _context.Skills.ToListAsync();

        var skillDTOs = skills.Select(p => ConvertToSkillDTO(p)).ToList();
        return skillDTOs;
    }

    public async Task<SkillDTO> Get(int id)
    {
        if (_context.Skills == null) return EmptySkillDTO();
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);

        if (skill == null) return EmptySkillDTO();
        return ConvertToSkillDTO(skill);
    }

    public async Task<SkillDTO> Add(SkillCreateDTO skillCreateDTO)
    {
        int id;
        if (_context.Skills == null) id = 0;
        else id = _context.Skills.Max(s => s.Id);

        var newSkill = new Skill
        {
            Id = id + 1,
            ImgUrl = skillCreateDTO.ImgUrl,
            Text = skillCreateDTO.Text,
            Type = skillCreateDTO.Type
        };

        if (_context.Skills == null) return EmptySkillDTO();
        await _context.Skills.AddAsync(newSkill);
        await _context.SaveChangesAsync();

        return ConvertToSkillDTO(newSkill);
    }

    public async Task<SkillDTO> Put(SkillDTO skillDTO)
    {
        if (_context.Skills == null) throw new Exception("Database Empty.");
        var updatedSkill = ConvertToSkill(skillDTO);

        _context.Update(updatedSkill);
        await _context.SaveChangesAsync();

        return skillDTO;
    }

    public async Task Delete(int id)
    {
        if (_context.Skills == null) return;
        var skill = await _context.Skills.FirstOrDefaultAsync(s => s.Id == id);

        if(skill == null) return;
        _context.Remove(skill);
        await _context.SaveChangesAsync();
    }
}
