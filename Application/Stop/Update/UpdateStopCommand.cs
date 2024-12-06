using AutoMapper;
using MediatR;

namespace Application.Stop.Update;

public class UpdateStopCommand : IRequest<string>
{
    public Guid Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<UpdateStopCommand, Domain.Entities.Stop>();
        }
    }
}