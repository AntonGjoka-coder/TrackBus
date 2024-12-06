using Domain.Entities;
using Infrastructure.Interfaces.Common;
using Infrastructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class JourneyRepository : IJourneyRepository
{
    private readonly IApplicationDbContext _dbContext;

    public JourneyRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(Journey journey)
    {
        if (journey == null)
        {
            throw new ArgumentNullException(nameof(journey));
        }
        
        journey.Id = Guid.NewGuid();

        _dbContext.Journeys.Add(journey);
        await _dbContext.SaveChangesAsync();

        return journey.Id;
    }
    
    public async Task Update(Journey journey)
    {
        if (journey == null)
        {
            throw new ArgumentNullException(nameof(journey));
        }

        var existingJourney = await _dbContext.Journeys
            .FirstOrDefaultAsync(j => j.Id == journey.Id);

        if (existingJourney == null)
        {
            throw new KeyNotFoundException("Journey not found.");
        }
        
        existingJourney.Code = journey.Code;
        existingJourney.Description = journey.Description;
        existingJourney.ServiceLinks = journey.ServiceLinks;
        
        _dbContext.Journeys.Update(existingJourney);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task Delete(Guid id)
    {
        var journey = await _dbContext.Journeys
            .FirstOrDefaultAsync(j => j.Id == id);

        if (journey == null)
        {
            throw new KeyNotFoundException("Journey not found.");
        }

        _dbContext.Journeys.Remove(journey);
        await _dbContext.SaveChangesAsync();
    }
    
    public async Task<Journey> GetById(Guid id)
    {
        var journey = await _dbContext.Journeys
            .Include(j => j.ServiceLinks) 
            .FirstOrDefaultAsync(j => j.Id == id);

        if (journey == null)
        {
            throw new KeyNotFoundException("Journey not found.");
        }

        return journey;
    }
    
    public async Task<List<Journey>> GetAll()
    {
        return await _dbContext.Journeys
            .Include(j => j.ServiceLinks)
            .ToListAsync();
    }
}