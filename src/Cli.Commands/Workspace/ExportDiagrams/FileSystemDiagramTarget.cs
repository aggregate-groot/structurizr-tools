using System.Threading.Tasks;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams
{
    public class FileSystemDiagramTarget : IDiagramTarget
    {
        public Task WriteAsync(Diagram diagram, string path)
        {
            throw new System.NotImplementedException();
        }
    }
}