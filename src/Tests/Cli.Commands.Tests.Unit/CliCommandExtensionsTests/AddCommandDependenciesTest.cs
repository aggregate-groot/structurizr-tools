using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Templating;
using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.CliCommandExtensionsTests
{
    /// <summary>
    /// Unit tests for the AddCommandDependencies method of the <see cref="CliCommandExtensions" /> class.
    /// </summary>
    public class AddCommandDependenciesTest
    {
        /// <summary>
        /// Creates a new instance of the <see cref="AddCommandDependenciesTest"/> class.
        /// </summary>
        public AddCommandDependenciesTest()
        {
            ServiceCollection services = new();
            services.AddCommandDependencies();

            _serviceProvider = services.BuildServiceProvider();
        }
        
        /// <summary>
        /// Tests that the <see cref="PhysicalConsole"/> type is registered with the
        /// service collection
        /// </summary>
        [Fact]
        public void Should_Register_Console()
        {
            Assert.IsType<PhysicalConsole>(
                _serviceProvider.GetRequiredService<IConsole>());
        }
        
        /// <summary>
        /// Tests that the <see cref="WrappedCliProvider"/> type is registered with the
        /// service collection
        /// </summary>
        [Fact]
        public void Should_Register_WrappedCliProvider()
        {
            Assert.IsType<WrappedCliProvider>(
                _serviceProvider.GetRequiredService<ICliProvider>());
        }
        
        /// <summary>
        /// Tests that the <see cref="DotNetTemplateEngine"/> type is registered with the
        /// service collection
        /// </summary>
        [Fact]
        public void Should_Register_DotNetTemplateEngine()
        {
            Assert.IsType<DotNetTemplateEngine>(
                _serviceProvider.GetRequiredService<ITemplateEngine>());
        }
        
        /// <summary>
        /// Tests that the <see cref="ConsolePrompt"/> type is registered with the
        /// service collection
        /// </summary>
        [Fact]
        public void Should_Register_ConsolePrompt()
        {
            Assert.IsType<ConsolePrompt>(
                _serviceProvider.GetRequiredService<IPrompt>());
        }
        
        /// <summary>
        /// Tests that the <see cref="PuppeteerDiagramExporter"/> type is registered with the
        /// service collection
        /// </summary>
        [Fact]
        public void Should_Register_PuppeteerDiagramExporter()
        {
            Assert.IsType<PuppeteerDiagramExporter>(
                _serviceProvider.GetRequiredService<IDiagramExporter>());
        }
        
        /// <summary>
        /// Tests that the <see cref="FileSystemDiagramTarget"/> type is registered with the
        /// service collection
        /// </summary>
        [Fact]
        public void Should_Register_FileSystemDiagramTargetr()
        {
            Assert.IsType<FileSystemDiagramTarget>(
                _serviceProvider.GetRequiredService<IDiagramTarget>());
        }

        private readonly ServiceProvider _serviceProvider;
    }
}