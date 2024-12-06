using MediatR;

namespace Application.Stop.GetById;

public record GetStopByIdCommand(Guid Id) : IRequest<Domain.Entities.Stop>;
