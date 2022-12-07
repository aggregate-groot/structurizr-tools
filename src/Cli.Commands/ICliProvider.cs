using System.Threading.Tasks;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands
{
    /// <summary>
    /// Interface for types that provide CLI command execution.
    /// </summary>
    public interface ICliProvider
    {
        /// <summary>
        /// Executes the provided <paramref name="command"/>.
        /// </summary>
        /// <param name="command">
        /// Required command to execute.
        /// </param>
        /// <param name="arguments">
        /// Optional arguments for the command.
        /// </param>
        /// <returns>
        /// The standard output of the command.
        /// </returns>
        Task<string> ExecuteAsync(string command, string arguments);
    }
}