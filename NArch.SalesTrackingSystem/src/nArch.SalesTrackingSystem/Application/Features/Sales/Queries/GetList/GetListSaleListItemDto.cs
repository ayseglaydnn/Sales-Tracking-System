using NArchitecture.Core.Application.Dtos;

namespace Application.Features.Sales.Queries.GetList;

public class GetListSaleListItemDto : IDto
{
    public int Id { get; set; }
    public Guid CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }

}