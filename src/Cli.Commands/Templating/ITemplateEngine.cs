using System.Threading.Tasks;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Templating
{
    /// <summary>
    /// Interface for types that write files using installed templates.
    /// </summary>
    public interface ITemplateEngine
    {
        /// <summary>
        /// Runs the provided <paramref name="template"/> to generate the output files.
        /// </summary>
        /// <param name="template">
        /// Required template used to generated the files.
        /// </param>
        Task RunAsync(ISourceTemplate template);
    }
}