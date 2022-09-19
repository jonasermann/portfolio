namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class Project
{
    [Required]
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? ImgUrl { get; set; }

    public string? Text { get; set; }

    public string? GitUrl { get; set; }
}
