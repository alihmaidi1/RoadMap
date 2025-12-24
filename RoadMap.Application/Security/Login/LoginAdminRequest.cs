using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;

namespace RoadMap.Application.Security.Login;

public class LoginAdminRequest
{
    public string UserName { get; set; }
    
    public string Password { get; set; }
}

public sealed class LoginAdminCommand: LoginAdminRequest, ICommand<TResult<LoginAdminResponse>>
{
    
    
}