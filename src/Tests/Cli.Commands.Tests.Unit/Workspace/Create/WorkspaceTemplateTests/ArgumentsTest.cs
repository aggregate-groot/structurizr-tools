using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.Create;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Workspace.Create.WorkspaceTemplateTests
{
    /// <summary>
    /// Unit tests for the Arguments property of the <see cref="WorkspaceTemplate" /> class.
    /// </summary>
    public class ArgumentsTest
    {
        /// <summary>
        /// Tests that the expected arguments are set for the properties of the template.
        /// </summary>
        [Fact]
        public void Should_Return_Expected_Argument_Mapping()
        {
            WorkspaceTemplate template = new()
            {
                DecisionOwnerName = "Derek Zoolander",
                DecisionOwnerEmail = "zoolander@blue.steel",
                Port = 8888
            };
            
            Assert.Equal(template.DecisionOwnerName, template.Arguments["decisionOwnerName"]);
            Assert.Equal(template.DecisionOwnerEmail, template.Arguments["decisionOwnerEmail"]);
            Assert.Equal(template.Port.ToString(), template.Arguments["structurizrPort"]);
        }
    }
}