namespace PozorDomStoreService.Domain.Entities
{
    public class HubEntity(Guid id, string name, double price)
    {
        public Guid Id { get; set; } = id;
        public string Name { get; set; } = name;
        public double Price { get; set; } = price;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
