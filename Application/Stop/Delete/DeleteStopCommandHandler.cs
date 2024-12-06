using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Stop.Delete;

public class DeleteStopCommandHandler : IRequestHandler<DeleteStopCommand>
{
    private readonly IStopRepository _stopRepository;

    public DeleteStopCommandHandler(IStopRepository stopRepository)
    {
        _stopRepository = stopRepository;
    }

    public async Task Handle(DeleteStopCommand request, CancellationToken cancellationToken)
    => await _stopRepository.Delete(request.Id);
    
}