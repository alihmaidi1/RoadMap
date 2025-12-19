using System.Reflection;
using NetArchTest.Rules;

namespace RoadMap.Test.ArchitectureTest;

public abstract class CommonLayerTests
{
    
    protected static void AssertLayerDoesNotHaveDependencyOnAnotherLayer(Assembly layerAssembly, Assembly anotherLayerAssembly)
    {
        Types.InAssembly(layerAssembly)
            .Should()
            .NotHaveDependencyOn(anotherLayerAssembly.GetName().Name)
            .GetResult()
            .ShouldBeSuccessful();
    }
    
}