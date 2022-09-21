using System.ComponentModel.DataAnnotations;

namespace PortfolioApi.Models;

public class Skill
{
    public int Id { get; set; }

    public string? ImgUrl { get; set; }

    public string? Text { get; set; }

    public int Type { get; set; }
}
