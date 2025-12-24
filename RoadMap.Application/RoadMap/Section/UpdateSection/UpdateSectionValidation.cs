using FluentValidation;

namespace RoadMap.Application.RoadMap.Section.UpdateSection;

internal sealed class UpdateSectionValidation: AbstractValidator<UpdateSectionCommand>
{
    public UpdateSectionValidation()
    {

        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x=>x.Id)
            .NotEmpty()
            .NotNull();
    }
    
}