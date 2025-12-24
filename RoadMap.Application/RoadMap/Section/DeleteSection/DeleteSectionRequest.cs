using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;

namespace RoadMap.Application.RoadMap.Section.DeleteSection;

public class DeleteSectionRequest
{
    public Guid Id { get; set; }
}


public sealed class DeleteSectionCommand: DeleteSectionRequest, ICommand<TResult<object>>
{
    
    
}