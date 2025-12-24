using FluentValidation;

namespace RoadMap.Application.RoadMap.Section.DeleteSection;

internal sealed class DeleteSectionValidation: AbstractValidator<DeleteSectionCommand>
{

    public DeleteSectionValidation()
    {

        RuleFor(x => x.Id)
            .NotEmpty()
            .NotNull();
    }
    
}