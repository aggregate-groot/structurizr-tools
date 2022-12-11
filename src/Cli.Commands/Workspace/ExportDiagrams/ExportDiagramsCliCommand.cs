using System;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams
{
    /// <summary>
    /// CLI command to export the diagrams in a Structurizr workspace to png files.
    /// </summary>
    [Command("export-diagrams", Description = "Export the diagrams in a Structurizr workspace to png file")]
    public class ExportDiagramsCliCommand : AsyncCliCommand
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ExportDiagramsCliCommand>"/> class.
        /// </summary>
        /// <param name="console">
        /// Required type used to render console output.
        /// </param>
        /// <param name="diagramExporter">
        /// Required type used to export diagrams from the Structurizr workspace.
        /// </param>
        /// <param name="diagramTarget">
        /// Required type used to save the diagram output.
        /// </param>
        public ExportDiagramsCliCommand(
            IConsole console,
            IDiagramExporter diagramExporter,
            IDiagramTarget diagramTarget)
        {
            _console = console 
                ?? throw new ArgumentNullException(nameof(console));
            _diagramExporter = diagramExporter
                ?? throw new ArgumentNullException(nameof(diagramExporter));
            _diagramTarget = diagramTarget 
                ?? throw new ArgumentNullException(nameof(diagramTarget));
        }
        
        /// <summary>
        /// Gets the HTTP port the local Structurizr instance is listening on.
        /// </summary>
        [Option(ShortName = "p", Description = "HTTP port the local Structurizr instance is listening on.")]
        public ushort Port { get; set; }

        /// <summary>
        /// Gets the directory to write the png images to.
        /// </summary>
        [Option(ShortName = "o", Description = "The directory to write the png images to.")]
        public string OutputDirectory { get; set; }

        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            if (!string.IsNullOrEmpty(OutputDirectory))
            {
                return 1;
            }

            await _console.Error.WriteLineAsync("Please provide the output directory (-o).");
            return 2;

        }
        
        private readonly IConsole _console;
        private readonly IDiagramExporter _diagramExporter;
        private readonly IDiagramTarget _diagramTarget;
    }
}