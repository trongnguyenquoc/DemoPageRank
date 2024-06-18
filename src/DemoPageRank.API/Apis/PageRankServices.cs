using MediatR;

namespace DemoPageRank.API.Apis;

public class PageRankServices(
    IMediator mediator,
    ILogger<PageRankServices> logger
    )
{
    public IMediator Mediator { get; set; } = mediator;

    public ILogger<PageRankServices> Logger { get; } = logger;
}
