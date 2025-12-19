using System.Reflection;

namespace RoadMap.Test.ArchitectureTest;

public class LayerTests: CommonLayerTests
{
    
    private static readonly Assembly ApplicationAssembly =  RoadMap.Application.AssemblyReference.Assembly;
    private static readonly Assembly DomainAssembly = RoadMap.Domain.AssemblyReference.Assembly;
    private static readonly Assembly InfrastructureAssembly = RoadMap.Infrastructure.AssemblyReference.Assembly;

    
    
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_ApplicationLayer()
    {
        AssertLayerDoesNotHaveDependencyOnAnotherLayer(
            DomainAssembly, 
            ApplicationAssembly);
    }
    
    [Fact]
    public void DomainLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        AssertLayerDoesNotHaveDependencyOnAnotherLayer(
            DomainAssembly, 
            InfrastructureAssembly);
    }
    
    
    [Fact]
    public void ApplicationLayer_ShouldNotHaveDependencyOn_InfrastructureLayer()
    {
        AssertLayerDoesNotHaveDependencyOnAnotherLayer(
            ApplicationAssembly, 
            InfrastructureAssembly);
    }
    
}