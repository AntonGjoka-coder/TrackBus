using Application.Journey.Create;
using AutoMapper;
using MediatR;

namespace Application.ServiceLink.Create;

public class CreateServiceLinkCommand : IRequest<Guid>
{
    public string Code { get; set; }
    public string Description { get; set; }
    public double Length { get; set; } 
    public double TravelTime { get; set; } 
    public Guid JourneyId { get; set; }
    public Guid? StartStopId { get; set; }
    public Guid? EndStopId { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateServiceLinkCommand, Domain.Entities.ServiceLink>().ReverseMap();
        }
    }
}