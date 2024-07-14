using Application.Features.Sales.Constants;
using Application.Features.Sales.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using NArchitecture.Core.Application.Pipelines.Authorization;
using NArchitecture.Core.Application.Pipelines.Caching;
using MediatR;
using static Application.Features.Sales.Constants.SalesOperationClaims;

namespace Application.Features.Sales.Commands.Create;

public class CreateSaleCommand : IRequest<CreatedSaleResponse>, ISecuredRequest, ICacheRemoverRequest
{
    public Guid CustomerId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalAmount { get; set; }
    public DateTime SaleDate { get; set; }
    public Product Product { get; set; }
    public Customer Customer { get; set; }

    public string[] Roles => [Admin, Write, SalesOperationClaims.Create];

    public bool BypassCache { get; }
    public string? CacheKey { get; }
    public string[]? CacheGroupKey => ["GetSales"];

    public class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, CreatedSaleResponse>
    {
        private readonly IMapper _mapper;
        private readonly ISaleRepository _saleRepository;
        private readonly SaleBusinessRules _saleBusinessRules;

        public CreateSaleCommandHandler(IMapper mapper, ISaleRepository saleRepository,
                                         SaleBusinessRules saleBusinessRules)
        {
            _mapper = mapper;
            _saleRepository = saleRepository;
            _saleBusinessRules = saleBusinessRules;
        }

        public async Task<CreatedSaleResponse> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            Sale sale = _mapper.Map<Sale>(request);

            await _saleRepository.AddAsync(sale);

            CreatedSaleResponse response = _mapper.Map<CreatedSaleResponse>(sale);
            return response;
        }
    }
}