using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RoadMap.Application.RoadMap.Section.UpdateSection;

namespace RoadMap.Application.RoadMap.Section.DeleteSection;

public class DeleteSectionEndPoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
        app.MapPost("/section/delete", 
                async ([FromBody]  DeleteSectionCommand request,ISender sender,CancellationToken cancellationToken) =>
                {
                    DeleteSectionCommand command = request.Adapt<DeleteSectionCommand>();
                    var result=await sender.Send(command);
                    return result;

                })
            .WithTags("Section")
            .WithSummary("delete section")
            .WithDescription("delete section");
    }
}