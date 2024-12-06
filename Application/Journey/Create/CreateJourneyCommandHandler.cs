using AutoMapper;
using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Journey.Create;

public class CreateJourneyCommandHandler : IRequestHandler<CreateJourneyCommand, Guid>
{
    private readonly IJourneyRepository _journeyRepository;
    private readonly IMapper _mapper;
    
    public CreateJourneyCommandHandler(IJourneyRepository journeyRepository, IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateJourneyCommand request, CancellationToken cancellationToken)
    {
        var journey = _mapper.Map<Domain.Entities.Journey>(request);
        return await _journeyRepository.Create(journey);
    }
}