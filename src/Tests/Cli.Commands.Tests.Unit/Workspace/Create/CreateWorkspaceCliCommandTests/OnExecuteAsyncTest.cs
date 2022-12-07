using McMaster.Extensions.CommandLineUtils;
using Moq;
using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.Create;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Workspace.Create.CreateWorkspaceCliCommandTests
{
    /// <summary>
    /// Unit tests for the OnExecuteAsync method of the <see cref="CreateWorkspaceCliCommand" /> class.
    /// </summary>
    public class OnExecuteAsyncTest
    {
        /// <summary>
        /// Tests that the values captured from the prompts are used as the template
        /// arguments.
        /// </summary>
        [Fact]
        public async Task Should_Execute_Template_With_Expected_Arguments()
        {
            const string decisionOwnerName = "Maury Ballstein";
            const string decisionOwnerEmail = "mballstein@balls.models";
            const string port = "7777";
            
            Mock<IPrompt> promptMock = new();
            promptMock
                .Setup(prompt => prompt.GetRequiredString("Decision Owner Name:", string.Empty))
                .Returns(decisionOwnerName);
            promptMock
                .Setup(prompt => prompt.GetRequiredString("Decision Owner Email:", string.Empty))
                .Returns(decisionOwnerEmail);
            promptMock
                .Setup(prompt => prompt.GetRequiredString("Structurizr Port:", string.Empty))
                .Returns(port);
            
            Mock<ITemplateEngine> templateEngineMock = new();

            CreateWorkspaceCliCommand command = new(promptMock.Object, templateEngineMock.Object);
            
            await command.OnExecuteAsync(new CommandLineApplication());
            
            templateEngineMock.Verify(engine 
                    => engine.RunAsync(It.Is<WorkspaceTemplate>(template 
                       => template.Name == "structurizr-workspace"
                       && template.DecisionOwnerName == decisionOwnerName
                       && template.DecisionOwnerEmail == decisionOwnerEmail
                       && template.Port.ToString() == port)),
                Times.Once);
        }
    }
}