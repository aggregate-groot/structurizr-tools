using System.Diagnostics.CodeAnalysis;

using Moq;
using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Templating.DotNetTemplateEngineTests
{
    /// <summary>
    /// Unit tests for the RunAsync method of the <see cref="DotNetTemplateEngine" /> class.
    /// </summary>
    public class RunAsyncTest
    {
        /// <summary>
        /// Tests that passing a null template argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public async Task NullTemplateShouldThrowException()
        {
            DotNetTemplateEngine engine = CreateEngine();
            
            ArgumentNullException exception = await Assert.ThrowsAsync<ArgumentNullException>(
                () => engine.RunAsync(null!));

            Assert.Equal("template", exception.ParamName);
        }
        
        /// <summary>
        /// Tests that an <see cref="InvalidOperationException"/> is thrown if the
        /// required template is not installed.
        /// </summary>
        [Fact]
        public async Task Should_Throw_Exception_When_Template_Not_Installed()
        {
            const string someTemplate = "some-template";
            _templateMock
                .SetupGet(template => template.Name)
                .Returns(someTemplate);
            _templateMock
                .SetupGet(template => template.Arguments)
                .Returns(new Dictionary<string, string>());

            _cliProviderMock
                .Setup(cli => cli.ExecuteAsync($"dotnet", $"new list {someTemplate}"))
                .ReturnsAsync($"No templates found matching: '{someTemplate}'.");

            DotNetTemplateEngine engine = CreateEngine();

            InvalidOperationException exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => engine.RunAsync(_templateMock.Object));
            
            Assert.Equal("The template 'some-template' is not installed.", exception.Message);
        }
        
        /// <summary>
        /// Tests that the expected template name and template arguments are sent to the dotnet
        /// CLI tool.
        /// </summary>
        [Fact]
        public async Task Should_Send_Template_Name_And_Arguments_To_Cli()
        {
            Dictionary<string, string> arguments = new ()
            {
                { "some-argument",  "some-value" }
            };

            _templateMock
                .SetupGet(template => template.Name)
                .Returns("some-template");
            _templateMock
                .SetupGet(template => template.Arguments)
                .Returns(arguments);

            const string templateResult = """
            Template Name  Short Name     Language  Tags
            -------------  -------------  --------  --------
            Some Project   some-template  [C#]      Some/Tag
            """;
            
            _cliProviderMock
                .Setup(cli => cli.ExecuteAsync($"dotnet", $"new list some-template"))
                .ReturnsAsync(templateResult);


            DotNetTemplateEngine engine = CreateEngine();
            await engine.RunAsync(_templateMock.Object);
            
            _cliProviderMock.Verify(cli => cli.ExecuteAsync(
                    "dotnet", "new some-template --some-argument \"some-value\""),
                    Times.Once);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="DotNetTemplateEngine"/> class configured for testing.
        /// </summary>
        /// <returns></returns>
        private DotNetTemplateEngine CreateEngine()
        {
            return new DotNetTemplateEngine(_cliProviderMock.Object);
        }

        private readonly Mock<ICliProvider> _cliProviderMock = new();
        private readonly Mock<ISourceTemplate> _templateMock = new();
    }
}