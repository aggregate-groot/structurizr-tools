using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams;
using Moq;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Workspace.ExportDiagrams.ExportDiagramsCliCommandTests
{
    /// <summary>
    /// Base class for testing the <see cref="ExportDiagramsCliCommand"/> class.
    /// </summary>
    public abstract class ExportDiagramsCliCommandTest : CliCommandTest
    {
        /// <summary>
        /// Gets the mock implementation of the <see cref="IDiagramExporter"/> interface.
        /// </summary>
        protected Mock<IDiagramExporter> DiagramExporterMock { get; } = new();

        /// <summary>
        /// Gets the mock implementation of the <see cref="IDiagramTarget"/> interface.
        /// </summary>
        protected Mock<IDiagramTarget> DiagramTargetMock { get; } = new();

        /// <summary>
        /// Creates a new instance of the <see cref="ExportDiagramsCliCommand"/> configured for testing.
        /// </summary>
        protected ExportDiagramsCliCommand CreateCommand()
        {
            return new ExportDiagramsCliCommand(
                ConsoleMock.Object,
                DiagramExporterMock.Object,
                DiagramTargetMock.Object);
        }
    }
}