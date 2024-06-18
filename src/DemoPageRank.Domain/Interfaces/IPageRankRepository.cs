using DemoPageRank.Domain.Entities;

namespace DemoPageRank.Domain.Interfaces;
public interface IPageRankRepository: IRepository<PageRank>
{
    Task<IEnumerable<PageRank>> GetAllAsync();

    Task<PageRank> AddAsync(PageRank pageRank);
}
