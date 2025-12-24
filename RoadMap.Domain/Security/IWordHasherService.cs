namespace RoadMap.Domain.Security;

public interface IWordHasherService
{
    public string Hash(string text);
 
    public bool IsValid(string text, string hash);

}