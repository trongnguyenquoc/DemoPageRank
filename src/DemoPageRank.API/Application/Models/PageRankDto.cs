namespace DemoPageRank.API.Application.Models;

public class PageRankDto
{
    public Guid Id { get; set; }
    public string Rank { get; set; }
    public string Phrase { get; set; }

    public DateTime CreatedDate { get; set; }
}
