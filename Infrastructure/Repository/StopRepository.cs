using Domain.Entities;
using Infrastructure.Interfaces.Common;
using Infrastructure.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class StopRepository : IStopRepository
{
    private readonly IApplicationDbContext _dbContext;

    public StopRepository(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Create(Stop stop)
    {
        if (stop == null)
        {
            throw new ArgumentNullException(nameof(stop));
        }

        stop.Id = Guid.NewGuid();

        _dbContext.Stops.Add(stop);
        await _dbContext.SaveChangesAsync();

        return stop.Id;
    }

    public async Task Update(Stop stop)
    {
        if (stop == null)
        {
            throw new ArgumentNullException(nameof(stop));
        }

        var existingStop = await _dbContext.Stops
            .FirstOrDefaultAsync(s => s.Id == stop.Id);

        if (existingStop == null)
        {
            throw new KeyNotFoundException("Stop not found.");
        }

        existingStop.Code = stop.Code;
        existingStop.Description = stop.Description;
        existingStop.Latitude = stop.Latitude;
        existingStop.Longitude = stop.Longitude;

        _dbContext.Stops.Update(existingStop);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Delete(Guid id)
    {
        var stop = await _dbContext.Stops
            .FirstOrDefaultAsync(s => s.Id == id);

        if (stop == null)
        {
            throw new KeyNotFoundException("Stop not found.");
        }

        _dbContext.Stops.Remove(stop);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Stop> GetById(Guid id)
    {
        var stop = await _dbContext.Stops
            .FirstOrDefaultAsync(s => s.Id == id);

        if (stop == null)
        {
            throw new KeyNotFoundException("Stop not found.");
        }

        return stop;
    }

    public async Task<List<Stop>> GetAll()
    {
        return await _dbContext.Stops
            .ToListAsync();
    }
}