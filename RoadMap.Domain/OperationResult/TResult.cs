using System.Net;

namespace RoadMap.Domain.OperationResult;

public class TResult<TValue>: Result
{
    
    public TResult(TValue? value, bool isSuccess,HttpStatusCode statusCode, Error? error=null)
        : base(isSuccess,statusCode, error)
    {
        this.value = value;
    }

    public TValue? value { get; }

}