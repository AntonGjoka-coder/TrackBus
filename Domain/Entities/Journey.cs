namespace Domain.Entities;

public class Journey
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public ICollection<ServiceLink>? ServiceLinks { get; set; }
}