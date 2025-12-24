using Carter;
using Mapster;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace RoadMap.Application.Security.Auth.Login;

public class LoginAdminEndPoint: ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        
        app.MapPost("/admin/login", 
                async ([FromBody]  LoginAdminRequest request,ISender sender,CancellationToken cancellationToken) =>
                {
                    LoginAdminCommand command = request.Adapt<LoginAdminCommand>();
                    var result=await sender.Send(command);
                    return result;

                })
            .WithTags("Admin")
            .WithSummary("login admin")
            .WithDescription("login admin");
    }
}