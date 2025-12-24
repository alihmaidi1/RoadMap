namespace RoadMap.Domain.Security;

public interface IJwtService
{
    
    public string GetToken(string userName);
    
}