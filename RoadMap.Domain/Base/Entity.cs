namespace RoadMap.Domain.Base;

public class Entity: IEntity
{
    
    
    public Guid Id { get; protected set; }

    
    public DateTime CreatedAt { get; private set; }=DateTime.UtcNow;
    public DateTime LastModified { get; private set; }=DateTime.UtcNow;
    public void SetCreatedBy()
    {
        CreatedAt = DateTime.UtcNow;
    }

    public void SetModified()
    {
        LastModified = DateTime.UtcNow;
    }
}