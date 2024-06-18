using DemoPageRank.API.Application.Commands;
using FluentValidation;

namespace DemoPageRank.API.Validations;

public class SearchPageRankCommandValidation : AbstractValidator<SearchPageRankCommand>
{
    public SearchPageRankCommandValidation(ILogger<SearchPageRankCommandValidation> logger)
    {
        RuleFor(pageRank => pageRank.PhraseSearch).NotEmpty();
    }
}
