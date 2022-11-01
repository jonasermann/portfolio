using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class IntroductionController : ControllerBase
{
    private readonly IIntroductionRepository _repo;
    public IntroductionController(IIntroductionRepository repo)
    {
        _repo = repo;
    }

    [HttpGet, AllowAnonymous]
    public async Task<IntroductionDTO> Get() => await _repo.Get();

    [HttpPut]
    public async Task<IntroductionDTO> Put(IntroductionDTO IntroductionDTO) => await _repo.Put(IntroductionDTO);
}
