using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;
using RoadMap.Domain.Repository;

namespace RoadMap.Application.RoadMap.Section.UpdateSection;

internal sealed class UpdateSectionCommandHandler: ICommandHandler<UpdateSectionCommand,TResult<object>>
{
    private readonly ISectionRepository  _sectionRepository;

    public UpdateSectionCommandHandler(ISectionRepository sectionRepository)
    {
        
        _sectionRepository = sectionRepository;
    }
    public async Task<TResult<object>> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
    {
        var section=await _sectionRepository.GetByIdAsync(request.Id);
        if (section == null)
        {
            return Result.NotFound<object>(Error.NotFound("Section not found"));
        }
        section.SetName(request.Name);
        await _sectionRepository.UpdateAsync(section);
        return Result.NoContent<object>();
    }
}