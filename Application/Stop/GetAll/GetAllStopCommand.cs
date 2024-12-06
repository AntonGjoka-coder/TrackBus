using MediatR;

namespace Application.Stop.GetAll;

public record GetAllStopCommand : IRequest<List<Domain.Entities.Stop>>;