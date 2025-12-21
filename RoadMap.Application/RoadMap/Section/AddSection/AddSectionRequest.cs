using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;

namespace RoadMap.Application.RoadMap.Section.AddSection;

public class AddSectionRequest
{
    
    public string Name { get; set; }
}

public sealed class AddSectionCommand: AddSectionRequest, ICommand<TResult<object>>
{
    
    
}