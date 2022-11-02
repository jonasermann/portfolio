using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class BackgroundParagraphsController : ControllerBase
{
    private readonly IBackgroundParagraphsRepository _repo;

    public BackgroundParagraphsController(IBackgroundParagraphsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet, AllowAnonymous]
    public async Task<List<BackgroundParagraphDTO>> Get() => await _repo.Get();

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<BackgroundParagraphDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<BackgroundParagraphDTO> Add(BackgroundParagraphCreateDTO AboutParagraphCreateDTO) => await _repo.Add(AboutParagraphCreateDTO);

    [HttpPut]
    public async Task<BackgroundParagraphDTO> Put(BackgroundParagraphDTO AboutParagraphDTO) => await _repo.Put(AboutParagraphDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
