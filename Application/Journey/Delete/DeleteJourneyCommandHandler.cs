using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Journey.Delete;

public class DeleteJourneyCommandHandler : IRequestHandler<DeleteJourneyCommand>
{
    private readonly IJourneyRepository _journeyRepository;

    public DeleteJourneyCommandHandler(IJourneyRepository journeyRepository)
    {
        _journeyRepository = journeyRepository;
    }

    public async Task Handle(DeleteJourneyCommand request, CancellationToken cancellationToken)
    => await _journeyRepository.Delete(request.Id);
    
}