using System.Diagnostics.CodeAnalysis;

using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Templating.DotNetTemplateEngineTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="DotNetTemplateEngine"/> class.
    /// </summary>
    public class ConstructorTest
    {
        /// <summary>
        /// Tests that passing a null cliProvider argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_CliProvider_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new DotNetTemplateEngine(null!));

            Assert.Equal("cliProvider", exception.ParamName);
        }
    }
}