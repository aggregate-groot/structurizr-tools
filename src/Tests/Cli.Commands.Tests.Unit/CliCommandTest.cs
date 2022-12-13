using McMaster.Extensions.CommandLineUtils;
using Moq;

using AggregateGroot.Structurizr.Tools.Cli.Commands;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit
{
    /// <summary>
    /// Base class for testing CLI commands.
    /// </summary>
    public abstract class CliCommandTest
    {
        /// <summary>
        /// Creates a new instance of the <see cref="CliCommandTest"/> class.
        /// </summary>
        protected CliCommandTest()
        {
            _consoleMock
                .SetupGet(console => console.Out)
                .Returns(_textWriterMock.Object);
            _consoleMock
                .SetupGet(console => console.Error)
                .Returns(_errorWriterMock.Object);
        }

        /// <summary>
        /// Gets the mock implementation of a console configured for testing.
        /// </summary>
        protected Mock<IConsole> ConsoleMock => _consoleMock;

        /// <summary>
        /// Gets the mock implementation of a prompt configured for testing.
        /// </summary>
        protected Mock<IPrompt> PromptMock => _promptMock;

        /// <summary>
        /// Gets the mock implementation of the <see cref="TextWriter"/> used to render
        /// output to the console.
        /// </summary>
        protected Mock<TextWriter> TextWriterMock => _textWriterMock;
        
        /// <summary>
        /// Gets the mock implementation of the <see cref="TextWriter"/> used to render
        /// error output to the console.
        /// </summary>
        protected Mock<TextWriter> ErrorWriterMock => _errorWriterMock;
        
        /// <summary>
        /// Configures the prompt mock for a test.
        /// </summary>
        /// <param name="promptText">
        /// Required text to prompt to the user.
        /// </param>
        /// <param name="value">
        /// Optional value to be returned for the given <paramref name="promptText"/>.
        /// </param>
        protected void SetupPrompt(string promptText, string value)
        {
            SetupPrompt(promptText, value, string.Empty);
        }

        /// <summary>
        /// Configures the prompt mock for a test.
        /// </summary>
        /// <param name="promptText">
        /// Required text to prompt to the user.
        /// </param>
        /// <param name="value">
        /// Optional value to be returned for the given <paramref name="promptText"/>.
        /// </param>
        /// <param name="defaultValue">
        /// Required value to offer as a default to the user.
        /// </param>
        protected void SetupPrompt(string promptText, string value, string defaultValue)
        {
            PromptMock
                .Setup(prompt => prompt.GetRequiredString(promptText, defaultValue))
                .Returns(value);
        }

        private readonly Mock<IConsole> _consoleMock = new();
        private readonly Mock<IPrompt> _promptMock = new();
        private readonly Mock<TextWriter> _textWriterMock = new();
        private readonly Mock<TextWriter> _errorWriterMock = new();
    }
}