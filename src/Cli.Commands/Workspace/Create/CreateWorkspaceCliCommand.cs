using System;
using System.Threading.Tasks;

using McMaster.Extensions.CommandLineUtils;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;

namespace AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.Create
{
    /// <summary>
    /// CLI command to create a new Structurizr workspace.
    /// </summary>
    [Command(
        "create",
        Description = "Creates a new Structurizr workspace.")]
    public class CreateWorkspaceCliCommand : AsyncCliCommand
    {

        /// <summary>
        /// Creates a new instance of the <see cref="CreateWorkspaceCliCommand"/>
        /// </summary>
        /// <param name="prompt">
        /// Required type used to prompt the user for input.
        /// </param>
        /// <param name="templateEngine">
        /// Required type used to execute the template.
        /// </param>
        public CreateWorkspaceCliCommand(IPrompt prompt, ITemplateEngine templateEngine)
        {
            _prompt = prompt 
                ?? throw new ArgumentNullException(nameof(prompt));
            _templateEngine = templateEngine 
                ?? throw new ArgumentNullException(nameof(templateEngine));
        }
        
        /// <inheritdoc />
        public override async Task<int> OnExecuteAsync(CommandLineApplication application)
        {
            string decisionOwnerName = _prompt.GetRequiredString("Decision Owner Name:", string.Empty);
            string decisionOwnerEmail = _prompt.GetRequiredString("Decision Owner Email:", string.Empty);
            string port = _prompt.GetRequiredString("Structurizr Port:", string.Empty);

            WorkspaceTemplate template = new()
            {
                DecisionOwnerName = decisionOwnerName,
                DecisionOwnerEmail = decisionOwnerEmail,
                Port = Convert.ToUInt16(port)
            };

            await _templateEngine.RunAsync(template);

            return 1;

        }
        
        private readonly IPrompt _prompt;
        private readonly ITemplateEngine _templateEngine;
    }
}
