using MediatR;

namespace Application.ServiceLink.GetById;

public record GetServiceLinkByIdCommand(Guid Id) : IRequest<Domain.Entities.ServiceLink>;