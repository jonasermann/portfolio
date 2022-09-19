namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class PortfolioImage
{
    [Required]
    public int Id { get; set; }

    public byte[]? ByteArray { get; set; }
}
