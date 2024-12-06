using Application.Journey.Create;
using AutoMapper;
using MediatR;

namespace Application.Stop.Create;

public class CreateStopCommand : IRequest<Guid>
{
    public string Code { get; set; }
    public string Description { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateStopCommand, Domain.Entities.Stop>().ReverseMap();
        }
    }
}