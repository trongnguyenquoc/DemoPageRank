using DemoPageRank.Domain.Entities;
using DemoPageRank.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DemoPageRank.Infrastructure.Repositories;
public class PageRankRepository : IPageRankRepository
{
    private readonly PageRankDbContext _context;
    public IUnitOfWork UnitOfWork => _context; 

    public PageRankRepository(PageRankDbContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context)); ;
    }

    public async Task<IEnumerable<PageRank>> GetAllAsync()
    {
        var listPageRank = await _context.PageRanks
                                    .AsNoTracking()
                                    .OrderByDescending(pageRank => pageRank.CreatedDate)
                                    .ToListAsync();

        return listPageRank;
    }

    public async Task<PageRank> AddAsync(PageRank pageRank)
    {
        var entity = await _context.PageRanks.AddAsync(pageRank);       
        return entity.Entity;
    }
}
