using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;
using PortfolioApi.Repositories;

namespace PortfolioApi.Controllers;

[ApiController, Authorize]
[Route("api/[controller]")]
public class ContactsController : Controller
{
    private readonly IContactsRepository _repo;

    public ContactsController(IContactsRepository repo)
    {
        _repo = repo;
    }

    [HttpGet, AllowAnonymous]
    public async Task<List<ContactDTO>> Get() => await _repo.Get();

    [HttpGet("{id}"), AllowAnonymous]
    public async Task<ContactDTO> Get(int id) => await _repo.Get(id);

    [HttpPost]
    public async Task<ContactDTO> Add(ContactCreateDTO contactCreateDTO) => await _repo.Add(contactCreateDTO);

    [HttpPut]
    public async Task<ContactDTO> Put(ContactDTO contactDTO) => await _repo.Put(contactDTO);

    [HttpDelete("{id}")]
    public async Task Delete(int id) => await _repo.Delete(id);
}
