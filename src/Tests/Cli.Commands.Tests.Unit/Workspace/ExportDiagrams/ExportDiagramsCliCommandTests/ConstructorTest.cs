﻿using System.Diagnostics.CodeAnalysis;

using Xunit;

using AggregateGroot.Structurizr.Tools.Cli.Commands.Workspace.ExportDiagrams;

namespace AggregateGroot.Structurizr.Cli.Commands.Tests.Unit.Workspace.ExportDiagrams.ExportDiagramsCliCommandTests
{
    /// <summary>
    /// Unit tests for the constructors of the <see cref="ExportDiagramsCommand"/> class.
    /// </summary>
    public class ConstructorTest : ExportDiagramsCliCommandTest
    {
        /// <summary>
        /// Tests that a new instance of the <see cref="ExportDiagramsCommand"/> class has the
        /// expected state.
        /// </summary>
        [Fact]
        public void New_Instance_Should_Have_Expected_State()
        {
            ExportDiagramsCliCommand command = new (
                ConsoleMock.Object,
                DiagramExporterMock.Object,
                DiagramTargetMock.Object);
            
            Assert.Equal(0, command.Port);
            Assert.Null(command.OutputDirectory);
        }

        /// <summary>
        /// Tests that passing a null console argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_Console_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new ExportDiagramsCliCommand(null!, DiagramExporterMock.Object, DiagramTargetMock.Object));

            Assert.Equal("console", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null diagramExporter argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_DiagramExporter_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new ExportDiagramsCliCommand(ConsoleMock.Object, null!, DiagramTargetMock.Object));

            Assert.Equal("diagramExporter", exception.ParamName);
        }

        /// <summary>
        /// Tests that passing a null diagramTarget argument will result
        /// in an <see cref="ArgumentNullException" /> being thrown.
        /// </summary>
        [Fact]
        [ExcludeFromCodeCoverage]
        public void Null_DiagramTarget_Should_Throw_Exception()
        {
            ArgumentNullException exception = Assert.Throws<ArgumentNullException>(
                () => new ExportDiagramsCliCommand(ConsoleMock.Object, DiagramExporterMock.Object, null!));

            Assert.Equal("diagramTarget", exception.ParamName);
        }
    }
}