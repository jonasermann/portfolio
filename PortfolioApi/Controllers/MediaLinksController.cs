using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaLinksController : ControllerBase
{
    private readonly IMediaLinksRepository _repo;
    public MediaLinksController(IMediaLinksRepository repo)
    {
        _repo = repo;
    }

    [HttpGet, AllowAnonymous]
    public List<MediaLinkDTO> Get() => _repo.Get();

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<MediaLinkDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<MediaLinkDTO> Add(MediaLinkCreateDTO mediaLinkCreateDTO) => await _repo.Add(mediaLinkCreateDTO);

    [HttpPut]
    public async Task<MediaLinkDTO> Put(MediaLinkDTO mediaLinkDTO) => await _repo.Put(mediaLinkDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
