using DemoPageRank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoPageRank.Infrastructure.EntityConfigurations;
public class PageRankEntityConfiguration : IEntityTypeConfiguration<PageRank>
{
    public void Configure(EntityTypeBuilder<PageRank> pageRankConfiguration)
    {
        pageRankConfiguration.HasKey(x => x.RankGuid);
    }
}
