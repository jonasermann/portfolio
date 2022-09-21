namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class AboutParagraph
{
    [Required]
    public int Id { get; set; }

    public string? Text { get; set; }
}
