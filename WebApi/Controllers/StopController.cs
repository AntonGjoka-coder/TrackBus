using Application.Stop.Create;
using Application.Stop.Delete;
using Application.Stop.GetAll;
using Application.Stop.GetById;
using Application.Stop.Update;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StopController : ControllerBase
{
    private readonly IMediator _mediator;

    public StopController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:guid}")]
    public async Task<Stop> GetById(Guid id)
        => await _mediator.Send(new GetStopByIdCommand(id));

    [HttpPost]
    public async Task<Guid> Create(CreateStopCommand command)
        => await _mediator.Send(command);
    
    [HttpPut]
    public async Task<string> Update(UpdateStopCommand command)
        => await _mediator.Send(command);

    [HttpDelete]
    public async Task Delete(Guid id)
        => await _mediator.Send(new DeleteStopCommand(id));
    
    [HttpGet("GetAll")]
    public async Task<List<Stop>> GetAll()
        => await _mediator.Send(new GetAllStopCommand());
}