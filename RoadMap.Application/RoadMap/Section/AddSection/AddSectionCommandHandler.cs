using MediatR;
using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;
using RoadMap.Domain.Repository;

namespace RoadMap.Application.RoadMap.Section.AddSection;

internal sealed class AddSectionCommandHandler: ICommandHandler<AddSectionCommand,TResult<object>>
{
    
    private readonly ISectionRepository  _sectionRepository;
    public AddSectionCommandHandler(ISectionRepository  sectionRepository)
    {
            _sectionRepository= sectionRepository;
    }
    
    
    public async Task<TResult<object>> Handle(AddSectionCommand request, CancellationToken cancellationToken)
    {
        var section = Domain.RoadMap.Section.Create(request.Name);
        _sectionRepository.AddAsync(section);
        return Result.Created<object>();
    }
}