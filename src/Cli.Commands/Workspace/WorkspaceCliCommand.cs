using System.Diagnostics.CodeAnalysis;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.Create;
using McMaster.Extensions.CommandLineUtils;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace
{
    /// <summary>
    /// Root command for working with Structurizr workspaces.
    /// </summary>
    [ExcludeFromCodeCoverage]
    [Command("workspace", Description = "Root command for working with Structurizr workspaces.")]
    [Subcommand(typeof(CreateWorkspaceCliCommand))]
    public class WorkspaceCliCommand : CliCommand
    {
        
    }
}