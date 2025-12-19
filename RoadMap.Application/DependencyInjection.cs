using Carter;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RoadMap.Application;

public static class DependencyInjection
{

    public static IServiceCollection AddApplications(this IServiceCollection services)
    {

        services.AddCarter(configurator: configurator =>
        {
            
            var modules = AssemblyReference.Assembly.GetTypes()
                .Where(t => t.IsAssignableTo(typeof(ICarterModule))).ToArray();

            configurator.WithModules(modules);
            
        });
        
        services.AddMediatR(c=>c.RegisterServicesFromAssembly(AssemblyReference.Assembly));
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly);
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;

        return services;
    }

}