using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Stop.GetById;

public class GetStopByIdCommandHandler : IRequestHandler<GetStopByIdCommand, Domain.Entities.Stop>
{
    private readonly IStopRepository _stopRepository;

    public GetStopByIdCommandHandler(IStopRepository stopRepository)
    {
        _stopRepository = stopRepository;
    }

    public async Task<Domain.Entities.Stop> Handle(GetStopByIdCommand request, CancellationToken cancellationToken)
        => await _stopRepository.GetById(request.Id);
}