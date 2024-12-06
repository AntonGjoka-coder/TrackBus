using Domain.Entities;
using Infrastructure.Interfaces.Common;

namespace Infrastructure.Interfaces.Repository;

public interface IStopRepository : IBaseRepository<Stop>, IScopedService
{
    
}