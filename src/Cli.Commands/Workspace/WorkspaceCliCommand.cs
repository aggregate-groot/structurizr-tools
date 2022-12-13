using System.Diagnostics.CodeAnalysis;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.Create;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace
{
    /// <summary>
    /// Root command for working with Structurizr workspaces.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command("workspace", Description = "Root command for working with Structurizr workspaces.")]
    [Subcommand(
        typeof(CreateWorkspaceCliCommand),
        typeof(ExportDiagramsCliCommand))]
    public class WorkspaceCliCommand : CliCommand
    {
        
    }
}