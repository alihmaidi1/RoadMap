using FluentAssertions;
using NetArchTest.Rules;
namespace RoadMap.Test.ArchitectureTest;

public static class TestResultExtensions
{
    
    internal static void ShouldBeSuccessful(this TestResult testResult)
    {
        testResult.FailingTypes?.Should().BeEmpty();
    }
}