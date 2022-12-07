using System.Collections.Generic;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Templating
{
    /// <summary>
    /// Interface for types that define a source template.
    /// </summary>
    public interface ISourceTemplate
    {
        /// <summary>
        /// Gets the name of the template.
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Gets the argument names and values for the template.
        /// </summary>
        IDictionary<string, string> Arguments { get; }
    }
}