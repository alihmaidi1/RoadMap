using RoadMap.Domain.MediatR;

namespace RoadMap.Application.RoadMap.Section.AddSection;

public class AddSectionRequest
{
    
    public string Name { get; set; }
}

public sealed class AddSectionCommand: AddSectionRequest, ICommand
{
    
    
}