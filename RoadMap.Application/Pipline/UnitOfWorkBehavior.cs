using System.Transactions;
using MediatR;
using RoadMap.Domain.OperationResult;
using RoadMap.Domain.Repository;

namespace RoadMap.Application.Pipline;

public class UnitOfWorkBehavior<TRequest,TResponse>: IPipelineBehavior<TRequest,TResponse>
{
    
    private readonly IUnitOfWork _unitOfWork;


    public UnitOfWorkBehavior(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        
    }
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {

            await _unitOfWork.BeginTransactionAsync();
            var response= await next();
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            await _unitOfWork.CommitTransactionAsync();
            return response;
        
    }
    
    
    
}