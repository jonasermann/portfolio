using Microsoft.AspNetCore.Mvc;
using PortfolioApi.Models;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactsController : Controller
{
    [HttpGet]
    public List<ContactDTO> Get()
    {
        var contacts = new List<ContactDTO>
        {
            new ContactDTO
            {
                ImgUrl = "/static/media/email-icon.dcb522da44dced268edb.png",

                Text = "jonas.ermann@hotmail.com"
            },

            new ContactDTO
            {
                ImgUrl = "/static/media/phone-icon.d27eb528725a134bd37e.jpg",

                Text = "076 815 56 56"
            }
        };

        return contacts;
    }
}
