using MediatR;

namespace Application.ServiceLink.Delete;

public record DeleteServiceLinkCommand(Guid Id) : IRequest;
