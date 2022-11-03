using PortfolioApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace PortfolioApi.Data;

public interface IPortfolioAppContext : IDisposable
{
    DbSet<Introduction>? Introduction { get; }
    DbSet<MediaLink>? MediaLinks { get; }
    DbSet<BackgroundParagraph>? BackgroundParagraphs { get; }
    DbSet<Project>? Projects { get; }
    DbSet<Contact>? Contacts { get; }
    DbSet<Skill>? Skills { get; }
    DbSet<PortfolioImage>? PortfolioImages { get; }

    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    EntityEntry Remove(object entity);
    EntityEntry Update(object entity);
}
