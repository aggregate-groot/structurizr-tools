using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace;
using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Structurizr.Tools.Cli
{
    /// <summary>
    /// Represents the root command for the CLI.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Subcommand(typeof(WorkspaceCliCommand))]
    public class RootCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        /// <param name="console">
        /// Required console.
        /// </param>
        public int OnExecute(CommandLineApplication application, IConsole console)
        {
            string versionNumber = Assembly
                .GetExecutingAssembly()
                .GetName()
                .Version?
                .ToString()!;
            
            console.WriteLine("-----------------------------------");
            console.WriteLine("Welcome to the Structurizr tools.");
            console.WriteLine("Use -h for more help.");
            console.WriteLine($"Version: {versionNumber}");
            console.WriteLine("-----------------------------------");
            
            application.ShowHelp();
            return 1;
        }
    }
}