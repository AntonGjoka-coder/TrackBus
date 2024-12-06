using MediatR;

namespace Application.Stop.Delete;

public record DeleteStopCommand(Guid Id) : IRequest;
