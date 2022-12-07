using System.Collections.Generic;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.Create
{
    /// <summary>
    /// Represents the values need to create a new workspace.
    /// </summary>
    public class WorkspaceTemplate : ISourceTemplate
    {
        /// <inheritdoc />
        public string Name => "structurizr-workspace";
        
        /// <summary>
        /// Gets or initializes the name of the primary owner of architecture
        /// decision records.
        /// </summary>
        public required string DecisionOwnerName { get; init; }
        
        /// <summary>
        /// Gets or initializes the email address of the primary owner of architecture
        /// decision records.
        /// </summary>
        public required string DecisionOwnerEmail { get; init; }
        
        /// <summary>
        /// Gets or sets the port that the Structurizr workspace is listening on.
        /// </summary>
        public required ushort Port { get; init; }
        
        /// <inheritdoc />
        public IDictionary<string, string> Arguments => new Dictionary<string, string>()
        {
            { "decisionOwnerName", DecisionOwnerName },
            { "decisionOwnerEmail", DecisionOwnerEmail },
            { "structurizrPort", Port.ToString() }
        };
    }
}