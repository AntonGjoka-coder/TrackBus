using Application.Stop.Create;
using AutoMapper;
using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.ServiceLink.Create;

public class CreateStopCommandHandler : IRequestHandler<CreateStopCommand, Guid>
{
    private readonly IStopRepository _stopRepository;
    private readonly IMapper _mapper;
    
    public CreateStopCommandHandler(IStopRepository stopRepository, IMapper mapper)
    {
        _stopRepository = stopRepository;
        _mapper = mapper;
    }

    public async Task<Guid> Handle(CreateStopCommand request, CancellationToken cancellationToken)
    {
        var stop = _mapper.Map<Domain.Entities.Stop>(request);
        return await _stopRepository.Create(stop);
    }
}