namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class HomeHistory
{
    [Required]
    public int Id { get; set; }

    public string? Text { get; set; }
}
