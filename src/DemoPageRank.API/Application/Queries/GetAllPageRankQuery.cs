using DemoPageRank.API.Application.Models;
using MediatR;

namespace DemoPageRank.API.Application.Queries;

public record GetAllPageRankQuery: IRequest<List<PageRankDto>>
{
}
