using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class AboutRepository : IAboutRepository
{
    private PortfolioAppContext _context;

    public AboutRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public AboutParagraphDTO ConvertToAboutParagraphDTO(AboutParagraph aboutParagraph) =>  new AboutParagraphDTO
    {
        Id = aboutParagraph.Id,
        Text = aboutParagraph.Text
    };

    public AboutParagraph ConvertToAboutParagraph(AboutParagraphDTO aboutParagraphDTO) => new AboutParagraph
    {
        Id = aboutParagraphDTO.Id,
        Text = aboutParagraphDTO.Text
    };

    public AboutParagraphDTO EmptyAboutParagraphDTO() => new AboutParagraphDTO { };

    public async Task<List<AboutParagraphDTO>> Get()
    {
        if (_context.AboutParagraphs == null) return new List<AboutParagraphDTO>() { };
        var aboutParagraphs = await _context.AboutParagraphs.ToListAsync();

        var aboutParagraphDTOs = aboutParagraphs.Select(p => ConvertToAboutParagraphDTO(p)).ToList();
        return aboutParagraphDTOs;
    }

    public async Task<AboutParagraphDTO> Get(int id)
    {
        if (_context.AboutParagraphs == null) return EmptyAboutParagraphDTO();
        var aboutParagraph = await _context.AboutParagraphs.FirstOrDefaultAsync(p => p.Id == id);

        if (aboutParagraph == null) return EmptyAboutParagraphDTO();
        return ConvertToAboutParagraphDTO(aboutParagraph);
    }

    public async Task<AboutParagraphDTO> Add(AboutParagraphCreateDTO aboutParagraphCreateDTO)
    {
        int id;
        if (_context.AboutParagraphs == null) id = 0;
        else id = await _context.AboutParagraphs.MaxAsync(p => p.Id);

        var newAboutParagraph = new AboutParagraph
        {
            Id = id + 1,
            Text = aboutParagraphCreateDTO.Text
        };

        if (_context.AboutParagraphs == null) return EmptyAboutParagraphDTO();
        await _context.AboutParagraphs.AddAsync(newAboutParagraph);
        await _context.SaveChangesAsync();

        return ConvertToAboutParagraphDTO(newAboutParagraph);
    }

    public async Task<AboutParagraphDTO> Put(AboutParagraphDTO aboutParagraphDTO)
    {
        if (_context.AboutParagraphs == null) throw new Exception("Database Empty.");
        var updatedAboutParagraph = ConvertToAboutParagraph(aboutParagraphDTO);

        _context.AboutParagraphs.Update(updatedAboutParagraph);
        await _context.SaveChangesAsync();

        return aboutParagraphDTO;
    }

    public async Task Delete(int id)
    {
        if (_context.AboutParagraphs == null) return;
        var aboutParagraph = await _context.AboutParagraphs.FirstOrDefaultAsync(p => p.Id == id);

        if (aboutParagraph == null) return;
        _context.Remove(aboutParagraph);
        await _context.SaveChangesAsync();
    }
}
