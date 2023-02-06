using System;

using Microsoft.Extensions.DependencyInjection;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands
{
    /// <summary>
    /// Extensions methods for registering the required services for the
    /// CLI commands.
    /// </summary>
    public static class CliCommandExtensions
    {
        /// <summary>
        /// Adds the required dependencies for the commands to the provided
        /// <paramref name="services"/>.
        /// </summary>
        /// <param name="services">
        /// Required service collection to add the dependencies to.
        /// </param>
        /// <returns>
        /// The provided service collection with the required dependencies added.
        /// </returns>
        [Obsolete("Use AggregateGroot.Structurizr.Tools.Cli.Commands.ServiceCollectionExtensions.AddStructurizrTools() instead.")]
        public static IServiceCollection AddCommandDependencies(this IServiceCollection services)
        {
            return services.AddStructurizrTools();
        }
    }
}