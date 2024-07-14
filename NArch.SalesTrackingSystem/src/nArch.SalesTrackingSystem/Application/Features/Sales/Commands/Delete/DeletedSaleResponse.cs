using NArchitecture.Core.Application.Responses;

namespace Application.Features.Sales.Commands.Delete;

public class DeletedSaleResponse : IResponse
{
    public int Id { get; set; }
}