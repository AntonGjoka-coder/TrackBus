using MediatR;

namespace Application.Journey.Delete;

public record DeleteJourneyCommand(Guid Id) : IRequest;
