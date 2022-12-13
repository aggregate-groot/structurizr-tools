namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams
{
    /// <summary>
    /// Represents a Structurizr diagram.
    /// </summary>
    public record Diagram
    {
        /// <summary>
        /// Gets or initializes the name of the diagram.
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Gets or initializes the eaw content of the diagram.
        /// </summary>
        public required byte[] Content { get; init; }
    }
}