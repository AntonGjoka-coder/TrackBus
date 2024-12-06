using Application.ServiceLink.Create;
using Application.ServiceLink.Delete;
using Application.ServiceLink.GetAll;
using Application.ServiceLink.GetById;
using Application.ServiceLink.Update;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ServiceLinkController : ControllerBase
{
    private readonly IMediator _mediator;

    public ServiceLinkController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ServiceLink> GetById(Guid id)
        => await _mediator.Send(new GetServiceLinkByIdCommand(id));

    [HttpPost]
    public async Task<Guid> Create(CreateServiceLinkCommand command)
        => await _mediator.Send(command);
    
    [HttpPut]
    public async Task<string> Update(UpdateServiceLinkCommand command)
        => await _mediator.Send(command);

    [HttpDelete]
    public async Task Delete(Guid id)
        => await _mediator.Send(new DeleteServiceLinkCommand(id));
    
    [HttpGet("GetAll")]
    public async Task<List<ServiceLink>> GetAll(Guid id)
        => await _mediator.Send(new GetAllServiceLinkCommand());
}