using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Repositories;
using System.Drawing;
using System.Reflection.Metadata.Ecma335;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PortfolioImagesController : ControllerBase
{
    private IPortfolioImagesRepository _repo;

    public PortfolioImagesController(IPortfolioImagesRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("{id}")]
    public IActionResult PortImage(int id) => id == 2 ? File(_repo.Get(id), "image/gif") : File(_repo.Get(id), "image/jpg");
}