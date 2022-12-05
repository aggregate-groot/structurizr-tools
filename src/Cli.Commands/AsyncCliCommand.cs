using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands
{
    /// <summary>
    /// Represents an asynchronous command that can be executed by the CLI.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public abstract class AsyncCliCommand
    {
        /// <summary>
        /// Runs when this command is executed.
        /// </summary>
        /// <param name="application">
        /// Required command line application.
        /// </param>
        public virtual Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            application.ShowHelp();
            return Task.FromResult(1);
        }
    }
}