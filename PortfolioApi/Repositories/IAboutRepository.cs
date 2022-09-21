using PortfolioApi.Models;

namespace PortfolioApi.Repositories;

public interface IAboutRepository
{
    public Task<List<AboutParagraphDTO>> Get();

    public Task<AboutParagraphDTO> Get(int id);

    public Task<AboutParagraphDTO> Add(AboutParagraphCreateDTO AboutParagraphCreateDTO);

    public Task<AboutParagraphDTO> Put(AboutParagraphDTO AboutParagraphDTO);

    public Task Delete(int id);
}
