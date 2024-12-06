using Domain.Entities;
using Infrastructure.Interfaces.Common;

namespace Infrastructure.Interfaces.Repository;

public interface IServiceLinkRepository: IBaseRepository<ServiceLink>, IScopedService
{
    
}