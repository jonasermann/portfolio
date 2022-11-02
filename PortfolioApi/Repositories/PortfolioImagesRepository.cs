using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class PortfolioImagesRepository : IPortfolioImagesRepository
{
    private readonly PortfolioAppContext _context;

    public PortfolioImagesRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public PortfolioImageDTO ConvertToProjectDTO(PortfolioImage portfolioImage) => new PortfolioImageDTO
    {
        Id = portfolioImage.Id,
        ByteArray = portfolioImage.ByteArray
    };

    public PortfolioImage ConvertToProject(PortfolioImageDTO portfolioImageDTO) => new PortfolioImage
    {
        Id = portfolioImageDTO.Id,
        ByteArray = portfolioImageDTO.ByteArray
    };

    public PortfolioImageDTO EmptyPortfolioImageDTO() => new PortfolioImageDTO { };

    public async Task<byte[]> Get(int id)
    {
        if(_context.PortfolioImages == null) return Array.Empty<byte>();

        var portfolioImages = await _context.PortfolioImages.FirstOrDefaultAsync(p => p.Id == id);

        if (portfolioImages == null) return Array.Empty<byte>();
        if (portfolioImages.ByteArray == null) return Array.Empty<byte>();

        return portfolioImages.ByteArray;
    }  

    public async Task<PortfolioImageDTO> Add(PortfolioImageCreateDTO portfolioImageCreateDTO)
    {
        int id;
        if (_context.PortfolioImages == null) id = 0;
        else id = await _context.PortfolioImages.MaxAsync(p => p.Id);

        var newPortfolioImage = new PortfolioImage
        {
            Id = id + 1,
            ByteArray = portfolioImageCreateDTO.ByteArray
        };

        if (_context.PortfolioImages == null) return EmptyPortfolioImageDTO();
        await _context.PortfolioImages.AddAsync(newPortfolioImage);
        await _context.SaveChangesAsync();

        return ConvertToProjectDTO(newPortfolioImage);
    }

    public async Task<PortfolioImageDTO> Put(PortfolioImageDTO portfolioImageDTO)
    {
        if (_context.PortfolioImages == null) throw new Exception("Database Empty.");
        var updatedPortfolioImage = ConvertToProject(portfolioImageDTO);

        _context.PortfolioImages.Update(updatedPortfolioImage);
        await _context.SaveChangesAsync();

        return portfolioImageDTO;
    }

    public async Task Delete(int id)
    {
        if (_context.PortfolioImages == null) return;
        var portfolioImage = await _context.PortfolioImages.FirstOrDefaultAsync(p => p.Id == id);

        if (portfolioImage == null) return;
        _context.Remove(portfolioImage);
        await _context.SaveChangesAsync();
    }
}
