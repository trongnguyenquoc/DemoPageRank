using DemoPageRank.Domain.Entities;
using DemoPageRank.Domain.Interfaces;
using DemoPageRank.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace DemoPageRank.Infrastructure;

public class PageRankDbContext : DbContext, IUnitOfWork
{
    public PageRankDbContext(DbContextOptions<PageRankDbContext> options): base(options)
    {
        Database.EnsureCreated();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase("demoPageRankDb");
    }

    public DbSet<PageRank> PageRanks { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PageRankEntityConfiguration());
    }

    public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        _ = await base.SaveChangesAsync(cancellationToken);
        return true;
    }
}
