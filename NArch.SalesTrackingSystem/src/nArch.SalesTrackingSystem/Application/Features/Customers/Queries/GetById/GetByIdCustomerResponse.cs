using NArchitecture.Core.Application.Responses;

namespace Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerResponse : IResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string CompanyName { get; set; }
}