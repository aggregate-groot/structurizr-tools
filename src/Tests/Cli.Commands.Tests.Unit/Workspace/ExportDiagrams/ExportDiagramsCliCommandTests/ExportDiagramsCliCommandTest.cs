using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Workspace.ExportDiagrams.ExportDiagramsCliCommandTests
{
    /// <summary>
    /// Base class for testing the <see cref="ExportDiagramsCliCommand"/> class.
    /// </summary>
    public abstract class ExportDiagramsCliCommandTest : CliCommandTest
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ExportDiagramsCliCommand"/> configured for testing.
        /// </summary>
        protected ExportDiagramsCliCommand CreateCommand()
        {
            return new ExportDiagramsCliCommand(ConsoleMock.Object);
        }
    }
}