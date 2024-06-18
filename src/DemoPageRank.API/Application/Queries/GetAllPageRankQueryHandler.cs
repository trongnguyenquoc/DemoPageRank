using DemoPageRank.API.Application.Models;
using DemoPageRank.Domain.Interfaces;
using MediatR;

namespace DemoPageRank.API.Application.Queries;

public class GetAllPageRankQueryHandler : IRequestHandler<GetAllPageRankQuery, List<PageRankDto>>
{
    private readonly IPageRankRepository _pageRankRepository;

    public GetAllPageRankQueryHandler(IPageRankRepository pageRankRepository)
    {
        _pageRankRepository = pageRankRepository;
    }

    public async Task<List<PageRankDto>> Handle(GetAllPageRankQuery request, CancellationToken cancellationToken)
    {
        var pageRanks = await _pageRankRepository.GetAllAsync();

        return pageRanks.Select(x => new PageRankDto
        {
            Id = x.RankGuid,
            Phrase = x.Phrase,
            Rank = x.Rank == -1 ? "N/A" : x.Rank.ToString(),
            CreatedDate = x.CreatedDate,
        }).ToList();
    }
}
