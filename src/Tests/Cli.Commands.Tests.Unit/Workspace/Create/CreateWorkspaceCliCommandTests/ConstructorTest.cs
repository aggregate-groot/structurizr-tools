using System.Diagnostics.CodeAnalysis;

using Moq;
using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.Create;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Workspace.Create.CreateWorkspaceCliCommandTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="CreateWorkspaceCliCommand" /> class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null prompt argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Prompt_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new CreateWorkspaceCliCommand(null!, new Mock<ITemplateEngine>().Object));

            Assert.Equal("prompt", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null templateEngine argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_TemplateEngine_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new CreateWorkspaceCliCommand(new Mock<IPrompt>().Object, null!));

            Assert.Equal("templateEngine", exception.ParamName);
        }
    }
}