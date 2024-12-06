using AutoMapper;
using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Stop.Update;

public class UpdateStopCommandHandler : IRequestHandler<UpdateStopCommand, string>
{
    private readonly IStopRepository _stopRepository;
    private readonly IMapper _mapper;

    public UpdateStopCommandHandler(IStopRepository stopRepository, IMapper mapper)
    {
        _stopRepository = stopRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateStopCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _stopRepository.GetById(request.Id);
            if (entity != null)
            {
                _mapper.Map(request, entity);
                await _stopRepository.Update(entity);    
                return "Data updated";
            }
            return "Data not found";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}