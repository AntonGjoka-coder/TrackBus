using AutoMapper;
using MediatR;

namespace Application.Journey.Create;

public class CreateJourneyCommand : IRequest<Guid>
{
    public string Code { get; set; }
    public string Description { get; set; }
    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<CreateJourneyCommand, Domain.Entities.Journey>().ReverseMap();
        }
    }
}