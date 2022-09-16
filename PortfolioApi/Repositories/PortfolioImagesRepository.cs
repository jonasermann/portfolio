using PortfolioApi.Data;
using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;

namespace PortfolioApi.Repositories;

public class PortfolioImagesRepository : IPortfolioImagesRepository
{
    private PortfolioAppContext _context;

    public PortfolioImagesRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public async Task<byte[]> Get(int id)
    {
        if(_context.PortfolioImages == null) return Array.Empty<byte>();

        var portfolioImages = await _context.PortfolioImages.FirstOrDefaultAsync(p => p.Id == id);

        if (portfolioImages == null) return Array.Empty<byte>();
        if (portfolioImages.ByteArray == null) return Array.Empty<byte>();

        return portfolioImages.ByteArray;
    }  
}
