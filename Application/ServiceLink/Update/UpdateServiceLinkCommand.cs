using AutoMapper;
using MediatR;

namespace Application.ServiceLink.Update;

public class UpdateServiceLinkCommand : IRequest<string>
{
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public double Length { get; set; } 
    public double TravelTime { get; set; } 

    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UpdateServiceLinkCommand, Domain.Entities.ServiceLink>();
        }
    }
}