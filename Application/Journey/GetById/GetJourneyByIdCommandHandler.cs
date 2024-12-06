using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Journey.GetById;

public class GetJourneyByIdCommandHandler : IRequestHandler<GetJourneyByIdCommand, Domain.Entities.Journey>
{
    private readonly IJourneyRepository _journeyRepository;

    public GetJourneyByIdCommandHandler(IJourneyRepository journeyRepository)
    {
        _journeyRepository = journeyRepository;
    }

    public async Task<Domain.Entities.Journey> Handle(GetJourneyByIdCommand request, CancellationToken cancellationToken)
    => await _journeyRepository.GetById(request.Id);
    
}