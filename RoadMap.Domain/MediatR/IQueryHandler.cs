using MediatR;

namespace RoadMap.Domain.MediatR;

public interface IQueryHandler<TCommand,TResult>:IRequestHandler<TCommand,TResult> where TCommand : IQuery<TResult>
{
    
}