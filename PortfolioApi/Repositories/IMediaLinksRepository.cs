using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IMediaLinksRepository
{
    public List<MediaLinkDTO> Get();

    public Task<MediaLinkDTO> Get(int id);

    public Task<MediaLinkDTO> Add(MediaLinkCreateDTO mediaLinkCreateDTO);

    public Task<MediaLinkDTO> Put(MediaLinkDTO mediaLinkDTO);

    public Task Delete(int id);
}
