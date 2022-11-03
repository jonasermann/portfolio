using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class BackgroundParagraphsRepository : IBackgroundParagraphsRepository
{
    private readonly PortfolioAppContext _context;

    public BackgroundParagraphsRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public static BackgroundParagraphDTO ConvertToBackgroundParagraphDTO(BackgroundParagraph backgroundParagraph) =>  new()
    {
        Id = backgroundParagraph.Id,
        Text = backgroundParagraph.Text
    };

    public static BackgroundParagraph ConvertToBackgroundParagraph(BackgroundParagraphDTO backgroundParagraphDTO) => new()
    {
        Id = backgroundParagraphDTO.Id,
        Text = backgroundParagraphDTO.Text
    };

    public BackgroundParagraphDTO EmptyBackgroundParagraphDTO() => new BackgroundParagraphDTO { };

    public List<BackgroundParagraphDTO> Get()
    {
        if (_context.BackgroundParagraphs == null) return new List<BackgroundParagraphDTO>() { };
        var backgroundParagraphs = _context.BackgroundParagraphs;

        var backgroundParagraphDTOs = backgroundParagraphs.Select(p => ConvertToBackgroundParagraphDTO(p)).ToList();
        return backgroundParagraphDTOs;
    }

    public async Task<BackgroundParagraphDTO> Get(int id)
    {
        if (_context.BackgroundParagraphs == null) return EmptyBackgroundParagraphDTO();
        var backgroundParagraph = await _context.BackgroundParagraphs.FirstOrDefaultAsync(p => p.Id == id);

        if (backgroundParagraph == null) return EmptyBackgroundParagraphDTO();
        return ConvertToBackgroundParagraphDTO(backgroundParagraph);
    }

    public async Task<BackgroundParagraphDTO> Add(BackgroundParagraphCreateDTO backgroundParagraphCreateDTO)
    {
        int id;
        if (_context.BackgroundParagraphs == null) id = 0;
        else id = await _context.BackgroundParagraphs.MaxAsync(p => p.Id);

        var newBackgroundParagraph = new BackgroundParagraph
        {
            Id = id + 1,
            Text = backgroundParagraphCreateDTO.Text
        };

        if (_context.BackgroundParagraphs == null) return EmptyBackgroundParagraphDTO();
        await _context.BackgroundParagraphs.AddAsync(newBackgroundParagraph);
        await _context.SaveChangesAsync();

        return ConvertToBackgroundParagraphDTO(newBackgroundParagraph);
    }

    public async Task<BackgroundParagraphDTO> Put(BackgroundParagraphDTO backgroundParagraphDTO)
    {
        if (_context.BackgroundParagraphs == null) throw new Exception("Database Empty.");
        var updatedBackgroundParagraph = ConvertToBackgroundParagraph(backgroundParagraphDTO);

        _context.BackgroundParagraphs.Update(updatedBackgroundParagraph);
        await _context.SaveChangesAsync();

        return backgroundParagraphDTO;
    }

    public async Task Delete(int id)
    {
        if (_context.BackgroundParagraphs == null) return;
        var backgroundParagraph = await _context.BackgroundParagraphs.FirstOrDefaultAsync(p => p.Id == id);

        if (backgroundParagraph == null) return;
        _context.Remove(backgroundParagraph);
        await _context.SaveChangesAsync();
    }
}
