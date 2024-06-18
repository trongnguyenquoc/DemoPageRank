using DemoPageRank.API.Application.Commands;
using DemoPageRank.API.Application.Models;
using DemoPageRank.API.Application.Queries;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DemoPageRank.API.Apis;

public static class PageRankApi
{
    public static RouteGroupBuilder MapPageRankApi(this IEndpointRouteBuilder builder)
    {
        var api = builder.MapGroup(prefix: "pageranks");
        
        api.MapGet("/", GetPageRank);
        api.MapPost("/", Search);

        return api;
    }

    public static async Task<Results<Ok<PageRankDto>, BadRequest<string>, ProblemHttpResult>> Search(
        SearchPageRankCommand command,
        [AsParameters] PageRankServices services)
    {
        var response = await services.Mediator.Send(command);

        if (response == null)
        {
            return TypedResults.BadRequest("Error");
        }

        return TypedResults.Ok<PageRankDto>(response);
    }

    public static async Task<Results<Ok<List<PageRankDto>>, ProblemHttpResult>> GetPageRank(
        [AsParameters] PageRankServices services)
    {
        var response = await services.Mediator.Send(new GetAllPageRankQuery());

        return TypedResults.Ok<List<PageRankDto>>(response);
    }


}
