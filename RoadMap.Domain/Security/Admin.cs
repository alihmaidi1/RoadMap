using RoadMap.Domain.Base;

namespace RoadMap.Domain.Security;

public class Admin: Entity, IEntity
{

    private Admin()
    {
        
        Id=Guid.NewGuid();
    }
    
    
    public string UserName { get; private set; }
    
    public string Password { get; private set; }
    
    public bool  IsSuperAdmin { get; private set; }=false;


    public static Admin Create(string username, string password,bool isSuperAdmin,IWordHasherService  wordHasher)
    {
        var admin = new Admin();
        admin.UserName = username;
        admin.Password = wordHasher.Hash(password);
        admin.IsSuperAdmin = isSuperAdmin;
        return admin;
    }
}