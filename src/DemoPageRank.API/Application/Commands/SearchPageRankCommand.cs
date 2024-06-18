using System.ComponentModel.DataAnnotations;
using DemoPageRank.API.Application.Models;
using MediatR;

namespace DemoPageRank.API.Application.Commands;

public record SearchPageRankCommand : IRequest<PageRankDto>
{
    [Required]
    public string PhraseSearch { get; set; }
}
