﻿namespace PortfolioApi.Models;
using System.ComponentModel.DataAnnotations;

public class MediaLink
{
    [Required]
    public int Id { get; set; }

    public string? ImgUrl {get; set; }

    public string? Url { get; set; }

    public string? Text { get; set; }
}
