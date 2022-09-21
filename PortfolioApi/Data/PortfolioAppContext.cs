using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApi.Data;

public class PortfolioAppContext : DbContext
{
    public PortfolioAppContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<HomeContent>? HomeContent { get; set; }
    public DbSet<HomeLink>? HomeLinks { get; set; }
    public DbSet<AboutParagraph> AboutParagraphs { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<Skill>? Skills { get; set; }
    public DbSet<PortfolioImage>? PortfolioImages { get; set; }
}
