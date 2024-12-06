using MediatR;

namespace Application.Journey.GetById;

public record GetJourneyByIdCommand(Guid Id) :IRequest<Domain.Entities.Journey>;