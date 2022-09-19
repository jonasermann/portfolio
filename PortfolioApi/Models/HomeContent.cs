namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class HomeContent
{
    [Required]
    public int Id { get; set; }

    public string? ProfilePicUrl { get; set; }

    public string? Text { get; set; }
}
