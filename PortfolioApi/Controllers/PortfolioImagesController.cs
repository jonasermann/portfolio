using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class PortfolioImagesController : ControllerBase
{
    private readonly IPortfolioImagesRepository _repo;

    public PortfolioImagesController(IPortfolioImagesRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<IActionResult> PortImage(int id) => id == 2 ? File(await _repo.Get(id), "image/gif") : File(await _repo.Get(id), "image/jpg");

    [HttpPost]
    public async Task<ActionResult<PortfolioImageDTO>> Add(PortfolioImageCreateDTO portfolioImageCreateDTO) => await _repo.Add(portfolioImageCreateDTO);

    [HttpPut]
    public async Task<ActionResult<PortfolioImageDTO>> Put(PortfolioImageDTO portfolioImageDTO) => await _repo.Put(portfolioImageDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
