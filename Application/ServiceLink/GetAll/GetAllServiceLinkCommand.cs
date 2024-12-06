using MediatR;

namespace Application.ServiceLink.GetAll;

public record GetAllServiceLinkCommand : IRequest<List<Domain.Entities.ServiceLink>>;