using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands
{
    /// <summary>
    /// Represents a command that can be executed by the CLI.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class CliCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        public virtual int OnExecute(CommandLineApplication application)
        {
            application.ShowHelp();
            return 1;
        }
    }
}