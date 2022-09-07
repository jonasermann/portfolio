using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public class PortfolioImagesRepository : IPortfolioImagesRepository
{
    private PortfolioAppContext _context;

    public PortfolioImagesRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public byte[] Get(int id) => _context.PortfolioImages.FirstOrDefault(p => p.Id == id).ByteArray;
    
}
