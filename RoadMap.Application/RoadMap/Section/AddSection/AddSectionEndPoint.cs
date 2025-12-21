using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RoadMap.Domain.OperationResult;

namespace RoadMap.Application.RoadMap.Section.AddSection;

public class AddSectionEndPoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {

        app.MapPost("/section/create", 
                async ([FromBody]  AddSectionRequest request,ISender sender,CancellationToken cancellationToken) =>
                {
                    AddSectionCommand command = request.Adapt<AddSectionCommand>();
                    var result=await sender.Send(command);
                    return result;

                })
            .WithTags("Section")
            .WithSummary("Add section")
            .WithDescription("Add section");
    }
}