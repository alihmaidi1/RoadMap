using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;
using RoadMap.Domain.Repository;

namespace RoadMap.Application.RoadMap.Section.DeleteSection;

internal sealed class DeleteSectionCommandHandler: ICommandHandler<DeleteSectionCommand,TResult<object>>
{
    
    private readonly ISectionRepository _sectionRepository;


    public DeleteSectionCommandHandler(ISectionRepository sectionRepository)
    {
        
        _sectionRepository = sectionRepository;
    }
    public async Task<TResult<object>> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
    {
        var section=await _sectionRepository.GetSectionByIdWithSpecializationAsync(request.Id);
        if (section == null)
        {
            return Result.NotFound<object>(Error.NotFound("Section not found"));
        }

        if (!section.EnsureCanBeDeleted())
        {

            return Result.ValidationFailure<object>(Error.ValidationFailures("Section can't be deleted because it has specialization"));
            
        }
        
        await _sectionRepository.DeleteAsync(section);
        return Result.NoContent<object>();
        
    }
}