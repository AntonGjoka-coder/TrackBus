using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.ServiceLink.GetAll;

public class GetAllServiceLinkCommandHandler : IRequestHandler<GetAllServiceLinkCommand, List<Domain.Entities.ServiceLink>>
{
    private readonly IServiceLinkRepository _serviceLinkRepository;

    public GetAllServiceLinkCommandHandler(IServiceLinkRepository serviceLinkRepository)
    {
        _serviceLinkRepository = serviceLinkRepository;
    }

    public async Task<List<Domain.Entities.ServiceLink>> Handle(GetAllServiceLinkCommand request, CancellationToken cancellationToken)
    {
        return await _serviceLinkRepository.GetAll();
    }
}