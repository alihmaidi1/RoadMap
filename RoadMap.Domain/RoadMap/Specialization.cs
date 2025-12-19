using RoadMap.Domain.Base;

namespace RoadMap.Domain.RoadMap;

public class Specialization: Entity, IEntity
{
    
    
    public string Name { get; private set; }
    

    private Specialization()
    {
        
        Id=Guid.NewGuid();
        
    }
    
    
    public static Specialization Create(string sectionName, Guid  sectionId)
    {
        ArgumentNullException.ThrowIfNull(sectionName);
        var specialization = new Specialization();
        specialization.Name=sectionName;
        specialization.SectionId=sectionId;
        return specialization;
    }

    public Guid SectionId { get; private set; }
    public Section Section { get; set; }

}