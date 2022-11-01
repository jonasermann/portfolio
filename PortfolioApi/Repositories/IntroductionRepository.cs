using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class IntroductionRepository : IIntroductionRepository
{
    private readonly PortfolioAppContext _context;

    public IntroductionRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public IntroductionDTO ConvertToIntroductionDTO(Introduction introduction) => new IntroductionDTO
    {
        Id = introduction.Id,
        ProfilePicUrl = introduction.ProfilePicUrl,
        Text = introduction.Text
    };

    public Introduction ConvertToIntroduction(IntroductionDTO introductionDTO) => new Introduction
    {
        Id = introductionDTO.Id,
        ProfilePicUrl = introductionDTO.ProfilePicUrl,
        Text = introductionDTO.Text
    };

    public IntroductionDTO EmptyIntroductionDTO() => new IntroductionDTO { };

    public async Task<IntroductionDTO> Get()
    {
        if (_context.Introduction == null) return EmptyIntroductionDTO();
        var introduction = await _context.Introduction.FirstOrDefaultAsync();

        if (introduction == null) return EmptyIntroductionDTO();
        return ConvertToIntroductionDTO(introduction);
    }

    public async Task<IntroductionDTO> Put(IntroductionDTO introductionDTO)
    {
        if (_context.Introduction == null) throw new Exception("Database Empty.");
        var updatedIntroduction = ConvertToIntroduction(introductionDTO);

        _context.Introduction.Update(updatedIntroduction);
        await _context.SaveChangesAsync();

        return introductionDTO;
    }
}
