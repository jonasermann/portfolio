using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Models;

public class Contact
{
    [Required]
    public int Id { get; set; }

    public string? ImgUrl { get; set; }

    public string? Text { get; set; }
}
