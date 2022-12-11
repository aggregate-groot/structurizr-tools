using System.Collections.Generic;
using System.Threading.Tasks;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams
{
    /// <summary>
    /// Interface for types that can export diagrams.
    /// </summary>
    public interface IDiagramExporter
    {
        /// <summary>
        /// Exports the diagrams in a Structurizr workspace to raw png images.
        /// </summary>
        /// <param name="port">
        /// The port of the workspace that Structurizr is listening on.
        /// </param>
        Task<IEnumerable<Diagram>> ExportAllAsync(ushort port);
    }
}