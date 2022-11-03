using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IBackgroundParagraphsRepository
{
    public List<BackgroundParagraphDTO> Get();

    public Task<BackgroundParagraphDTO> Get(int id);

    public Task<BackgroundParagraphDTO> Add(BackgroundParagraphCreateDTO AboutParagraphCreateDTO);

    public Task<BackgroundParagraphDTO> Put(BackgroundParagraphDTO AboutParagraphDTO);

    public Task Delete(int id);
}
