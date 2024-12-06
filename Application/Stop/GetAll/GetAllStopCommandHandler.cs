using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Stop.GetAll;

public class GetAllStopCommandHandler : IRequestHandler<GetAllStopCommand, List<Domain.Entities.Stop>>
{
    private readonly IStopRepository _stopRepository;

    public GetAllStopCommandHandler(IStopRepository stopRepository)
    {
        _stopRepository = stopRepository;
    }

    public async Task<List<Domain.Entities.Stop>> Handle(GetAllStopCommand request, CancellationToken cancellationToken)
    {
        return await _stopRepository.GetAll();
    }
}