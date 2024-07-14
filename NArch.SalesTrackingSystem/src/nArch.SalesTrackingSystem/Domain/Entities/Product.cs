using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Product : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public int StockQuantity { get; set; }
    public decimal UnitPrice { get; set; }

    public virtual ICollection<Sale> Sales { get; set; }

    public Product()
    {

    }
    public Product(int id, string name, string description, int stockQuantity, decimal unitPrice)
    {
        Id = id;
        Name = name;
        Description = description;
        StockQuantity = stockQuantity;
        UnitPrice = unitPrice;
    }
}
