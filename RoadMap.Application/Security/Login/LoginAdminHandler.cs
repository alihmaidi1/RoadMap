using RoadMap.Domain.MediatR;
using RoadMap.Domain.OperationResult;
using RoadMap.Domain.Repository;
using RoadMap.Domain.Security;

namespace RoadMap.Application.Security.Login;

internal sealed class LoginAdminHandler: ICommandHandler<LoginAdminCommand,TResult<LoginAdminResponse>>
{

    private readonly IAdminRepository _adminRepository;
    private readonly IWordHasherService  _wordHasherService;
    private readonly IJwtService _jwtService;
    public LoginAdminHandler(IJwtService jwtService,IAdminRepository adminRepository, IWordHasherService wordHasherService)
    {
        _adminRepository = adminRepository;
        _wordHasherService = wordHasherService;
        _jwtService = jwtService;
        
    }
    public async Task<TResult<LoginAdminResponse>> Handle(LoginAdminCommand request, CancellationToken cancellationToken)
    {
        var admin=_adminRepository.GetQueryable().FirstOrDefault(x => x.UserName==request.UserName);
        if (admin == null)
        {
            return Result.ValidationFailure<LoginAdminResponse>(Error.ValidationFailures("username or password is not correct"));
        }

        if (!_wordHasherService.IsValid(request.Password,admin.Password))
        {
            return Result.ValidationFailure<LoginAdminResponse>(Error.ValidationFailures("username or password is not correct"));
            
        }

        var token = _jwtService.GetToken(request.UserName);
        var response = new LoginAdminResponse();
        response.Token=token;
        return Result.Success(response);
        
    }
}