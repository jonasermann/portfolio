using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class AboutController : ControllerBase
{
    private IAboutRepository _repo;

    public AboutController(IAboutRepository repo)
    {
        _repo = repo;
    }

    [HttpGet, AllowAnonymous]
    public async Task<List<AboutParagraphDTO>> Get() => await _repo.Get();

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<AboutParagraphDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<AboutParagraphDTO> Add(AboutParagraphCreateDTO AboutParagraphCreateDTO) => await _repo.Add(AboutParagraphCreateDTO);

    [HttpPut]
    public async Task<AboutParagraphDTO> Put(AboutParagraphDTO AboutParagraphDTO) => await _repo.Put(AboutParagraphDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
