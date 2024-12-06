namespace Domain.Entities;

public class ServiceLink
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public double Length { get; set; } 
    public double TravelTime { get; set; }
    public Guid JourneyId { get; set; }
    public Journey? Journey { get; set; }
    public Guid? StartStopId { get; set; }
    public Stop? StartStop { get; set; }
    public Guid? EndStopId { get; set; }
    public Stop? EndStop { get; set; }
}