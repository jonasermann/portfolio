using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : Controller
{
    private IContactsRepository _repo;

    public ContactsController(IContactsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public List<ContactDTO> Get() => _repo.Get();
}
