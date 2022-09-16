using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

namespace PortfolioApi.Data;

public class PortfolioAppContext : DbContext
{
    public PortfolioAppContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<HomeContent>? HomeContent { get; set; }
    public DbSet<HomeHistory>? HomeHistory { get; set; }
    public DbSet<HomeLinks>? HomeLinks { get; set; }
    public DbSet<Project>? Projects { get; set; }
    public DbSet<Contact>? Contacts { get; set; }
    public DbSet<Skill>? Skills { get; set; }
    public DbSet<PortfolioImage>? PortfolioImages { get; set; }
}
