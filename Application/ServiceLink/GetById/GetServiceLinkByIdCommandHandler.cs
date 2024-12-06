using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.ServiceLink.GetById;

public class GetServiceLinkByIdCommandHandler : IRequestHandler<GetServiceLinkByIdCommand, Domain.Entities.ServiceLink>
{
    private readonly IServiceLinkRepository _serviceLinkRepository;

    public GetServiceLinkByIdCommandHandler(IServiceLinkRepository serviceLinkRepository)
    {
        _serviceLinkRepository = serviceLinkRepository;
    }

    public async Task<Domain.Entities.ServiceLink> Handle(GetServiceLinkByIdCommand request,
        CancellationToken cancellationToken)
        => await _serviceLinkRepository.GetById(request.Id);
}