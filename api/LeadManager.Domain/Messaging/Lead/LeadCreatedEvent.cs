using LeadManager.Domain.Enuns;

namespace LeadManager.Domain.Messaging.Lead;

public class LeadCreatedEvent : Event
{
    public Guid Id { get; set; }
    public uint JobId { get; set; }
    public ContactCreatedEvent Contact { get; set; }
    public string Description { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public LeadStatus Status { get; set; }
    public DateTime CreateAt { get; set; }
}
