using System.ComponentModel.DataAnnotations;

namespace DemoPageRank.Domain.Entities;
public class PageRank
{
    public Guid RankGuid { get; set; }

    [Required]
    public string Phrase { get; set; }

    public int Rank { get; set; }

    public DateTime CreatedDate { get; set; }
}
