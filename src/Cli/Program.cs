using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace AggregateGroot.Structurizr.Tools.Cli
{
    /// <summary>
    /// Represents the main command line application.
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">
        /// Optional command line arguments.
        /// </param>
        private static void Main(string[] args)
        {         
            ServiceProvider services = new ServiceCollection()
                .AddSingleton(PhysicalConsole.Singleton)
                .BuildServiceProvider();

            CommandLineApplication<RootCommand> application = new ();
            application.HelpOption("-h|--help");

            application.Conventions
                .UseDefaultConventions()
                .UseConstructorInjection(services);
            
            application.Execute(args);
        }
    }
}