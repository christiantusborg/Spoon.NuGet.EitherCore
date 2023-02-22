namespace Spoon.NuGet.EitherCore;

using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PipelineBehaviors;

/// <summary>
/// Class ServiceCollectionExtensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds the either pipeline behavior.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <returns>IServiceCollection.</returns>
    public static IServiceCollection AddEitherPipelineBehavior(this IServiceCollection services)
    {
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(EitherPipelineBehavior<,>));

        return services;
    }
}