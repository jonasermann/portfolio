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

    public BackgroundParagraphDTO ConvertToAboutParagraphDTO(BackgroundParagraph backgroundParagraph) =>  new BackgroundParagraphDTO
    {
        Id = backgroundParagraph.Id,
        Text = backgroundParagraph.Text
    };

    public BackgroundParagraph ConvertToAboutParagraph(BackgroundParagraphDTO aboutParagraphDTO) => new BackgroundParagraph
    {
        Id = aboutParagraphDTO.Id,
        Text = aboutParagraphDTO.Text
    };

    public BackgroundParagraphDTO EmptyAboutParagraphDTO() => new BackgroundParagraphDTO { };

    public async Task<List<BackgroundParagraphDTO>> Get()
    {
        if (_context.BackgroundParagraphs == null) return new List<BackgroundParagraphDTO>() { };
        var aboutParagraphs = await _context.BackgroundParagraphs.ToListAsync();

        var aboutParagraphDTOs = aboutParagraphs.Select(p => ConvertToAboutParagraphDTO(p)).ToList();
        return aboutParagraphDTOs;
    }

    public async Task<BackgroundParagraphDTO> Get(int id)
    {
        if (_context.BackgroundParagraphs == null) return EmptyAboutParagraphDTO();
        var aboutParagraph = await _context.BackgroundParagraphs.FirstOrDefaultAsync(p => p.Id == id);

        if (aboutParagraph == null) return EmptyAboutParagraphDTO();
        return ConvertToAboutParagraphDTO(aboutParagraph);
    }

    public async Task<BackgroundParagraphDTO> Add(BackgroundParagraphCreateDTO backgroundParagraphCreateDTO)
    {
        int id;
        if (_context.BackgroundParagraphs == null) id = 0;
        else id = await _context.BackgroundParagraphs.MaxAsync(p => p.Id);

        var newAboutParagraph = new BackgroundParagraph
        {
            Id = id + 1,
            Text = backgroundParagraphCreateDTO.Text
        };

        if (_context.BackgroundParagraphs == null) return EmptyAboutParagraphDTO();
        await _context.BackgroundParagraphs.AddAsync(newAboutParagraph);
        await _context.SaveChangesAsync();

        return ConvertToAboutParagraphDTO(newAboutParagraph);
    }

    public async Task<BackgroundParagraphDTO> Put(BackgroundParagraphDTO backgroundParagraphDTO)
    {
        if (_context.BackgroundParagraphs == null) throw new Exception("Database Empty.");
        var updatedAboutParagraph = ConvertToAboutParagraph(backgroundParagraphDTO);

        _context.BackgroundParagraphs.Update(updatedAboutParagraph);
        await _context.SaveChangesAsync();

        return backgroundParagraphDTO;
    }

    public async Task Delete(int id)
    {
        if (_context.BackgroundParagraphs == null) return;
        var aboutParagraph = await _context.BackgroundParagraphs.FirstOrDefaultAsync(p => p.Id == id);

        if (aboutParagraph == null) return;
        _context.Remove(aboutParagraph);
        await _context.SaveChangesAsync();
    }
}
