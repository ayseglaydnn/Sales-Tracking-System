using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sales.Commands.Update;

public class UpdatedSaleResponse : IResponse
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }

}