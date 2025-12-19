using MediatR;

namespace RoadMap.Domain.MediatR;


public interface ICommand<TResult> : IRequest<TResult>
{
    
    
    
}
public interface ICommand :IRequest
{
    
}