using RoadMap.Domain.Base;

namespace RoadMap.Domain.RoadMap;

public class Section : Entity,IEntity
{

    private Section()
    {
        
        Id=Guid.NewGuid();
    }
    
    public string Name { get; private set; }

    public static Section Create(string sectionName)
    {
        ArgumentNullException.ThrowIfNull(sectionName);
        var section = new Section();
        section.Name=sectionName;
        return section;
    }
    
    
    public ICollection<Specialization> Specializations { get; private set; } = new List<Specialization>();

    
}

