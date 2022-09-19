namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class Skill
{
    [Required]
    public int Id { get; set; }

    public string? ImgUrl { get; set; }

    public string? Text { get; set; }

    public int Type { get; set; }
}
