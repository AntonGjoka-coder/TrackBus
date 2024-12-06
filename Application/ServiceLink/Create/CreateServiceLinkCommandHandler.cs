using AutoMapper;
using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.ServiceLink.Create;

public class CreateServiceLinkCommandHandler : IRequestHandler<CreateServiceLinkCommand, Guid>
{
    private readonly IServiceLinkRepository _serviceLinkRepository;
    private readonly IMapper _mapper;
    
    public CreateServiceLinkCommandHandler(IServiceLinkRepository serviceLinkRepository, IMapper mapper)
    {
        _serviceLinkRepository = serviceLinkRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateServiceLinkCommand request, CancellationToken cancellationToken)
    {
        var serviceLink = _mapper.Map<Domain.Entities.ServiceLink>(request);
        return await _serviceLinkRepository.Create(serviceLink);
    }
}