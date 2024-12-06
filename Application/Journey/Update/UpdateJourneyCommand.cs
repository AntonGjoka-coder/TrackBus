using AutoMapper;
using MediatR;

namespace Application.Journey.Update;

public class UpdateJourneyCommand : IRequest<string>
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UpdateJourneyCommand, Domain.Entities.Journey>();
        }
    }
}