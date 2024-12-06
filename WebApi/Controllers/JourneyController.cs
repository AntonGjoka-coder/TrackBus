using Application.Journey.Create;
using Application.Journey.Delete;
using Application.Journey.GetAll;
using Application.Journey.GetById;
using Application.Journey.Update;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class JourneyController : ControllerBase
{
    private readonly IMediator _mediator;

    public JourneyController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<Journey> GetById(Guid id)
        => await _mediator.Send(new GetJourneyByIdCommand(id));

    [HttpPost]
    public async Task<Guid> Create(CreateJourneyCommand command)
        => await _mediator.Send(command);
    
    [HttpPut]
    public async Task<string> Update(UpdateJourneyCommand command)
        => await _mediator.Send(command);

    [HttpDelete]
    public async Task Delete(Guid id)
        => await _mediator.Send(new DeleteJourneyCommand(id));
    
    [HttpGet("GetAll")]
    public async Task<List<Journey>> GetAll(Guid id)
        => await _mediator.Send(new GetAllJourneysCommand());
}