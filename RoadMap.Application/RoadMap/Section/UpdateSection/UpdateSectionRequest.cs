using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;

namespace RoadMap.Application.RoadMap.Section.UpdateSection;

public class UpdateSectionRequest
{
    
    public Guid Id { get; set; }
    public string Name { get; set; }
}


public sealed class UpdateSectionCommand: UpdateSectionRequest, ICommand<TResult<object>>
{
    
    
}