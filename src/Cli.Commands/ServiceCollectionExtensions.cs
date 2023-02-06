using System;

using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands
{
    /// <summary>
    /// Extension methods for adding the Structurizr tools to a service collection.
    /// </summary>
    public static class ServiceCollectionExtensions
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
        public static IServiceCollection AddStructurizrTools(this IServiceCollection services)
        {
            services
                .AddSingleton(PhysicalConsole.Singleton)
                .AddSingleton<IPrompt, ConsolePrompt>()
                .AddSingleton<ICliProvider, WrappedCliProvider>()
                .AddSingleton<ITemplateEngine, DotNetTemplateEngine>()
                .AddSingleton<IDiagramExporter, PuppeteerDiagramExporter>()
                .AddSingleton<IDiagramTarget, FileSystemDiagramTarget>();

            return services;
        }
    }
}