using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.ServiceLink.Delete;

public class DeleteServiceLinkCommandHandler : IRequestHandler<DeleteServiceLinkCommand>
{
    private readonly IServiceLinkRepository _serviceLinkRepository;

    public DeleteServiceLinkCommandHandler(IServiceLinkRepository serviceLinkRepository)
    {
        _serviceLinkRepository = serviceLinkRepository;
    }

    public async Task Handle(DeleteServiceLinkCommand request, CancellationToken cancellationToken)
    => await _serviceLinkRepository.Delete(request.Id);
    
}