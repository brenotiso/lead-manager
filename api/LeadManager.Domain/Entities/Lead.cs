using LeadManager.Domain.Enuns;
using LeadManager.Domain.Interfaces;

namespace LeadManager.Domain.Entities;

public class Lead : Entity, IAggregateRoot
{
    public uint JobId { get; set; }
    public Guid ContactId { get; set; }
    public string Description { get; set; }
    public string Suburb { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public decimal? AcceptedPrice { get; set; }
    public LeadStatus Status { get; set; }
    public DateTime CreateAt { get; set; }

    public Contact Contact { get; set; }

    public void SetAcceptedPrice()
    {
        AcceptedPrice = Price > 500 ? decimal.Multiply(Price, new decimal(0.9)) : Price;
    }
}
