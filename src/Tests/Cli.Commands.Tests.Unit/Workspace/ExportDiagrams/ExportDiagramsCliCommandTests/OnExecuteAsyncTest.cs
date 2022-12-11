using McMaster.Extensions.CommandLineUtils;
using Moq;
using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Workspace.ExportDiagrams.ExportDiagramsCliCommandTests
{
    /// <summary>
    /// Unit tests for the OnExecuteAsync method of the <see cref="ExportDiagramsCliCommand"/> class.
    /// </summary>
    public class OnExecuteAsyncTest : ExportDiagramsCliCommandTest
    {
        /// <summary>
        /// Tests that an error is written to the console when the output directory is not provided.
        /// </summary>
        /// <param name="outputDirectory">
        /// Value used to set the OutputDirectory in the test.
        /// </param>
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public async Task Should_Show_Error_When_Output_Directory_Not_Provided(string outputDirectory)
        {
            ExportDiagramsCliCommand command = CreateCommand();

            command.Port = 80;
            command.OutputDirectory = outputDirectory;

            int result = await command.OnExecuteAsync(new CommandLineApplication());
            
            Assert.True(result > 1);
            ErrorWriterMock.Verify(
                writer => writer.WriteLineAsync("Please provide the output directory (-o)."), 
                Times.Once);
        }

        /// <summary>
        /// Tests that the diagrams returned from the exporter are saved to the target.
        /// </summary>
        [Fact]
        public async Task Should_Save_Each_Exported_Diagram_To_Target()
        {
            const ushort port = 8080;
            
            List<Diagram> diagrams = new()
            {
                new Diagram()
                {
                    Content = new byte[] { 2, 4, 8 },
                    Name = "Diagram1"
                },
                new Diagram()
                {
                    Content = new byte[] { 16, 32, 64 },
                    Name = "Diagram2"
                }
            };

            DiagramExporterMock
                .Setup(exporter => exporter.ExportAllAsync(port))
                .ReturnsAsync(diagrams);
            
            ExportDiagramsCliCommand command = CreateCommand();
            command.Port = port;
            command.OutputDirectory = "/some/path";
            
            await command.OnExecuteAsync(new CommandLineApplication());
            
            DiagramTargetMock.Verify(
                target => target.WriteAsync(diagrams[0], command.OutputDirectory),
                Times.Once);
            DiagramTargetMock.Verify(
                target => target.WriteAsync(diagrams[1], command.OutputDirectory),
                Times.Once);
        }
    }
}