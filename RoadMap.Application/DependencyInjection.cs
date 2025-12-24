using Carter;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RoadMap.Application.Pipline;
using RoadMap.Application.Security.Service;
using RoadMap.Domain.Security;

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
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IWordHasherService, WordHasherService>();
        services.AddScoped<IJwtService, JwtService>();
        services.AddMediatR(c=>c.RegisterServicesFromAssembly(AssemblyReference.Assembly));
        services.AddValidatorsFromAssembly(AssemblyReference.Assembly,includeInternalTypes:true);
        ValidatorOptions.Global.DefaultClassLevelCascadeMode = CascadeMode.Stop;
        ValidatorOptions.Global.DefaultRuleLevelCascadeMode = CascadeMode.Stop;
        services.AddOptions<JwtSetting>()
            .BindConfiguration("Jwt")
            .ValidateDataAnnotations()
            .ValidateOnStart();
        
        return services;
    }

}