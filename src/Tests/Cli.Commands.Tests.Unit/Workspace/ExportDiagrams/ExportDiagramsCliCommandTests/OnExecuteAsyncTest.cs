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
    }
}