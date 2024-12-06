using Domain.Entities;
using Infrastructure.Interfaces.Common;
using Infrastructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class ServiceLinkRepository : IServiceLinkRepository
{
    private readonly IApplicationDbContext _dbContext;

    public ServiceLinkRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
     public async Task<Guid> Create(ServiceLink serviceLink) 
     {
         if (serviceLink == null)
         {
             throw new ArgumentNullException(nameof(serviceLink));
         }
 
         serviceLink.Id = Guid.NewGuid();
 
         _dbContext.ServiceLinks.Add(serviceLink);
         await _dbContext.SaveChangesAsync();
 
         return serviceLink.Id;
     }
 
     public async Task Update(ServiceLink serviceLink)
     {
         if (serviceLink == null)
         {
             throw new ArgumentNullException(nameof(serviceLink));
         }
 
         var existingServiceLink = await _dbContext.ServiceLinks
             .FirstOrDefaultAsync(sl => sl.Id == serviceLink.Id);
 
         if (existingServiceLink == null)
         {
             throw new KeyNotFoundException("ServiceLink not found.");
         }
 
         existingServiceLink.Code = serviceLink.Code;
         existingServiceLink.Description = serviceLink.Description;
         existingServiceLink.Length = serviceLink.Length;
         existingServiceLink.TravelTime = serviceLink.TravelTime;
         existingServiceLink.StartStopId = serviceLink.StartStopId;
         existingServiceLink.EndStopId = serviceLink.EndStopId;
 
         _dbContext.ServiceLinks.Update(existingServiceLink);
         await _dbContext.SaveChangesAsync();
     }
     
     public async Task Delete(Guid id)
     {
         var serviceLink = await _dbContext.ServiceLinks
             .FirstOrDefaultAsync(sl => sl.Id == id);
 
         if (serviceLink == null)
         {
             throw new KeyNotFoundException("ServiceLink not found.");
         }
 
         _dbContext.ServiceLinks.Remove(serviceLink);
         await _dbContext.SaveChangesAsync();
     }
     
     public async Task<ServiceLink> GetById(Guid id)
     {
         var serviceLink = await _dbContext.ServiceLinks
             .Include(sl => sl.StartStop) 
             .Include(sl => sl.EndStop)
             .FirstOrDefaultAsync(sl => sl.Id == id);
 
         if (serviceLink == null)
         {
             throw new KeyNotFoundException("ServiceLink not found.");
         }
 
         return serviceLink;
     }
     
     public async Task<List<ServiceLink>> GetAll()
     {
         return await _dbContext.ServiceLinks
             .Include(sl => sl.StartStop) 
             .Include(sl => sl.EndStop)
             .ToListAsync();
     }
}