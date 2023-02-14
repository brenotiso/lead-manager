namespace LeadManager.Domain.Queries.Results;

public class SearchLeadResultDto
{
    public Guid Id { get; set; }
    public uint JobId { get; set; }
    public ContactResultDto Contact { get; set; }
    public string Description { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public decimal AcceptedPrice { get; set; }
    public DateTime CreatedAt { get; set; }
}
