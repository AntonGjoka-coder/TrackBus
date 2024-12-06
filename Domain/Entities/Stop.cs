namespace Domain.Entities;

public class Stop
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}