using System.Threading.Tasks;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams
{
    /// <summary>
    /// Represents a target to when diagrams can be saved.
    /// </summary>
    public interface IDiagramTarget
    {
        /// <summary>
        /// Writes the provided <paramref name="diagram"/> to a output target.
        /// </summary>
        /// <param name="diagram">
        /// Required diagram to write.
        /// </param>
        /// <param name="path">
        /// Required path to write the diagram to.
        /// </param>
        Task WriteAsync(Diagram diagram, string path);
    }
}