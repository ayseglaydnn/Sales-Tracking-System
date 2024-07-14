using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;
public class Sale : Entity<int>
{
    public Guid CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }

    public virtual Product Product { get; set; }
    public virtual Customer Customer { get; set; }

    public Sale()
    {

    }
    public Sale(int id, Guid customerId, int productId, int quantity, decimal totalAmount, DateTime saleDate)
    {
        Id = id;
        CustomerId = customerId;
        ProductId = productId;
        Quantity = quantity;
        TotalAmount = totalAmount;
        SaleDate = saleDate;
    }
}
