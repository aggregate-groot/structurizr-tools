using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Threading.Tasks;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams
{
    /// <summary>
    /// File system implementation of the <see cref="IDiagramTarget"/> interface.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class FileSystemDiagramTarget : IDiagramTarget
    {
        /// <inheritdoc />
        public Task WriteAsync(Diagram diagram, string path)
        {
            string output = Path.Combine(path, diagram.Name);
            return File.WriteAllBytesAsync($"{output}.png", diagram.Content);
        }
    }
}