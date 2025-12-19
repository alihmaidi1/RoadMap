namespace RoadMap.Domain.Base;

public interface IEntity
{
    
    Guid Id { get;}

    
    DateTime CreatedAt { get; }
    
    DateTime LastModified { get; }
    
    void SetCreatedBy();
    void SetModified();
    
}