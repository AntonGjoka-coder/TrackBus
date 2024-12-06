using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Journey.GetAll;

public class GetAllJourneysCommandHandler : IRequestHandler<GetAllJourneysCommand, List<Domain.Entities.Journey>>
{
    private readonly IJourneyRepository _journeyRepository;

    public GetAllJourneysCommandHandler(IJourneyRepository journeyRepository)
    {
        _journeyRepository = journeyRepository;
    }

    public async Task<List<Domain.Entities.Journey>> Handle(GetAllJourneysCommand request, CancellationToken cancellationToken)
    {
        return await _journeyRepository.GetAll();
    }
}