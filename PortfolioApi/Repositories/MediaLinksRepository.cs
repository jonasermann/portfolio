using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public class MediaLinksRepository : IMediaLinksRepository
{
    private readonly PortfolioAppContext _context;

    public MediaLinksRepository(PortfolioAppContext context)
    {
        _context = context;
    }

    public MediaLinkDTO ConvertToMediaLinkDTO(MediaLink mediaLink) => new()
    {
        Id = mediaLink.Id,
        ImgUrl = mediaLink.ImgUrl,
        Url = mediaLink.Url,
        Text = mediaLink.Text
    };

    public MediaLink ConvertToMediaLink(MediaLinkDTO mediaLinkDTO) => new()
    {
        Id = mediaLinkDTO.Id,
        ImgUrl = mediaLinkDTO.ImgUrl,
        Url = mediaLinkDTO.Url,
        Text = mediaLinkDTO.Text
    };

    public MediaLinkDTO EmptyMediaLinkDTO() => new MediaLinkDTO { };

    public async Task<List<MediaLinkDTO>> Get()
    {
        if (_context.MediaLinks == null) return new List<MediaLinkDTO>() { };
        var mediaLinks = await _context.MediaLinks.ToListAsync();

        var mediaLinkDTOs = mediaLinks.Select(m => ConvertToMediaLinkDTO(m)).ToList();
        return mediaLinkDTOs;
    }

    public async Task<MediaLinkDTO> Get(int id)
    {
        if (_context.MediaLinks == null) return EmptyMediaLinkDTO();
        var mediaLink = await _context.MediaLinks.FirstOrDefaultAsync(p => p.Id == id);

        if (mediaLink == null) return EmptyMediaLinkDTO();
        return ConvertToMediaLinkDTO(mediaLink);
    }

    public async Task<MediaLinkDTO> Add(MediaLinkCreateDTO mediaLinkCreateDTO)
    {
        int id;
        if (_context.MediaLinks == null) id = 0;
        else id = await _context.MediaLinks.MaxAsync(p => p.Id);

        var newMediaLink = new MediaLink
        {
            Id = id + 1,
            ImgUrl = mediaLinkCreateDTO.ImgUrl,
            Text = mediaLinkCreateDTO.Text
        };

        if (_context.MediaLinks == null) return EmptyMediaLinkDTO();
        await _context.MediaLinks.AddAsync(newMediaLink);
        await _context.SaveChangesAsync();

        return ConvertToMediaLinkDTO(newMediaLink);
    }

    public async Task<MediaLinkDTO> Put(MediaLinkDTO mediaLinkDTO)
    {
        if (_context.MediaLinks == null) throw new Exception("Database Empty.");
        var updatedMediaLink = ConvertToMediaLink(mediaLinkDTO);

        _context.MediaLinks.Update(updatedMediaLink);
        await _context.SaveChangesAsync();

        return mediaLinkDTO;
    }

    public async Task Delete(int id)
    {
        if (_context.MediaLinks == null) return;
        var mediaLink = await _context.MediaLinks.FirstOrDefaultAsync(p => p.Id == id);

        if (mediaLink == null) return;
        _context.Remove(mediaLink);
        await _context.SaveChangesAsync();
    }
}
