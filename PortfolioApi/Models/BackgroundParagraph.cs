namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class BackgroundParagraph
{
    [Required]
    public int Id { get; set; }

    public string? Text { get; set; }
}
