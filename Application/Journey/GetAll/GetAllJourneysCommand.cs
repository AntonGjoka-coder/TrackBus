using MediatR;

namespace Application.Journey.GetAll;

public record GetAllJourneysCommand : IRequest<List<Domain.Entities.Journey>>;