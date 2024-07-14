using Domain.Entities;
using NArchitecture.Core.Persistence.Repositories;

namespace Application.Services.Repositories;

public interface ISaleRepository : IAsyncRepository<Sale, int>, IRepository<Sale, int>
{
}