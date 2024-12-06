using AutoMapper;
using Infrastructure.Interfaces.Repository;
using MediatR;

namespace Application.Journey.Update;

public class UpdateJourneyCommandHandler : IRequestHandler<UpdateJourneyCommand, string>
{
    private readonly IJourneyRepository _journeyRepository;
    private readonly IMapper _mapper;

    public UpdateJourneyCommandHandler(IJourneyRepository journeyRepository, IMapper mapper)
    {
        _journeyRepository = journeyRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateJourneyCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _journeyRepository.GetById(request.Id);
            if (entity != null)
            {
                _mapper.Map(request, entity);
                await _journeyRepository.Update(entity);    
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