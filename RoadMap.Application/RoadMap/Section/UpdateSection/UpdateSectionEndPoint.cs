using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RoadMap.Application.RoadMap.Section.AddSection;

namespace RoadMap.Application.RoadMap.Section.UpdateSection;

public class UpdateSectionEndPoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
        app.MapPost("/section/update", 
                async ([FromBody]  UpdateSectionCommand request,ISender sender,CancellationToken cancellationToken) =>
                {
                    UpdateSectionCommand command = request.Adapt<UpdateSectionCommand>();
                    var result=await sender.Send(command);
                    return result;

                })
            .WithTags("Section")
            .WithSummary("update section")
            .WithDescription("update section");
    }
}