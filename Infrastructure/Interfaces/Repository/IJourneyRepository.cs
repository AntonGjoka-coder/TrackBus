using Domain.Entities;
using Infrastructure.Interfaces.Common;

namespace Infrastructure.Interfaces.Repository;

public interface IJourneyRepository: IBaseRepository<Journey>, IScopedService
{
    
}