using System.Net;
using System.Text.RegularExpressions;
using DemoPageRank.API.Application.Models;
using DemoPageRank.API.Extensions;
using DemoPageRank.Domain.Entities;
using DemoPageRank.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Options;

namespace DemoPageRank.API.Application.Commands;

public class SearchPageRankCommandHandler : IRequestHandler<SearchPageRankCommand, PageRankDto>
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IPageRankRepository _pageRankRepository;
    private readonly SearchSettings _searchProviderSettings;

    public SearchPageRankCommandHandler(
        IHttpClientFactory httpClientFactory,
        IPageRankRepository pageRankRepository,
        IOptions<SearchSettings> searchProviderSettings)
    {
        _httpClientFactory = httpClientFactory;
        _pageRankRepository = pageRankRepository;
        _searchProviderSettings = searchProviderSettings.Value;
    }

    public async Task<PageRankDto> Handle(SearchPageRankCommand request, CancellationToken cancellationToken)
    {        
        var searchUrl = $"{_searchProviderSettings.BaseUrl}?num={_searchProviderSettings.Limit}&q={request.PhraseSearch}";

        var httpClient = _httpClientFactory.CreateClient();
        var searchResponse = await httpClient.GetStringAsync(searchUrl, cancellationToken);

        var results = ParseGoogleResults(searchResponse);
        var rank = AnalyzeResults(results, _searchProviderSettings.LookupUrl);

        var pageRank = await _pageRankRepository.AddAsync(new PageRank
        {
            RankGuid = Guid.NewGuid(),
            Phrase = request.PhraseSearch,
            Rank = rank,
            CreatedDate = DateTime.UtcNow,
        });

        await _pageRankRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        return new PageRankDto
        {
            Id = pageRank.RankGuid,
            Rank = rank == -1 ? "N/A" : rank.ToString(),
            Phrase = pageRank.Phrase,
            CreatedDate = pageRank.CreatedDate,
        };
    }

    private List<string> ParseGoogleResults(string response)
    {
        var results = new List<string>();
        var matches = Regex.Matches(response, @"<a href=""\/url\?q=(.*?)&amp;");

        foreach (Match match in matches)
        {
            results.Add(WebUtility.UrlDecode(match.Groups[1].Value));
        }

        return results;
    }

    private int AnalyzeResults(List<string> results, string lookupUrl)
    {
        for (int i = 0; i < results.Count; i++)
        {
            if (results[i].Contains(lookupUrl))
            {
                return i + 1; 
            }
        }
        return -1;
    }
}
