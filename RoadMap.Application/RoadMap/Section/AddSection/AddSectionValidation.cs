using FluentValidation;

namespace RoadMap.Application.RoadMap.Section.AddSection;

internal sealed class AddSectionValidation: AbstractValidator<AddSectionCommand>
{

    public AddSectionValidation()
    {
        RuleFor(x=>x.Name)
            .NotNull()
            .NotEmpty();
        
    }
    
}