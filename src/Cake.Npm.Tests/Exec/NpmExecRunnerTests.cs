namespace Cake.Npm.Tests.Exec;

using Cake.Core.Diagnostics;
using Xunit;

public class NpmExecRunnerTests
{
    public sealed class TheRunScriptMethod
    {
        [Fact]
        public void Should_Redirect_Standard_Error()
        {
            var fixture = new NpmExecFixture();
            fixture.Settings.RedirectStandardError = true;
            fixture.Settings.ExecCommand = "foo bar";

            var result = fixture.Run();

            Assert.True(result.Process.RedirectStandardError);
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new NpmExecFixture
            {
                Settings = null
            };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Throw_If_Command_Is_Null()
        {
            // Given
            var fixture = new NpmExecFixture();
            fixture.Settings.ExecCommand = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.IsInvalidOperationException("Must provide a command to execute.");
        }

        [Fact]
        public void Should_Add_Command_To_Arguments_If_Not_Null()
        {
            // Given
            var fixture = new NpmExecFixture();
            fixture.Settings.ExecCommand = "foo bar";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("exec \"foo bar\"", result.Args);
        }

        [Fact]
        public void Should_Add_CommandArguments_To_Arguments_If_Not_Empty()
        {
            // Given
            var fixture = new NpmExecFixture();
            fixture.Settings.ExecCommand = "hello";
            fixture.Settings.Arguments.Add("--foo=bar");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("exec \"hello\" -- --foo=bar", result.Args);
        }
        
        [Theory]
        [InlineData(NpmLogLevel.Default, "exec \"hello\"")]
        [InlineData(NpmLogLevel.Info, "exec --loglevel info \"hello\"")]
        [InlineData(NpmLogLevel.Silent, "exec --silent \"hello\"")]
        [InlineData(NpmLogLevel.Silly, "exec --loglevel silly \"hello\"")]
        [InlineData(NpmLogLevel.Verbose, "exec --loglevel verbose \"hello\"")]
        [InlineData(NpmLogLevel.Warn, "exec --warn \"hello\"")]
        public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
            NpmLogLevel logLevel, 
            string expected)
        {
            // Given
            var fixture = new NpmExecFixture();
            fixture.Settings.ExecCommand = "hello";
            fixture.Settings.LogLevel = logLevel;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }

        [Theory]
        [InlineData(Verbosity.Diagnostic, "exec --loglevel verbose \"hello\"")]
        [InlineData(Verbosity.Minimal, "exec --warn \"hello\"")]
        [InlineData(Verbosity.Normal, "exec \"hello\"")]
        [InlineData(Verbosity.Quiet, "exec --silent \"hello\"")]
        [InlineData(Verbosity.Verbose, "exec --loglevel info \"hello\"")]
        public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
            Verbosity verbosity,
            string expected)
        {
            // Given
            var fixture = new NpmExecFixture();
            fixture.Settings.ExecCommand = "hello";
            fixture.Settings.CakeVerbosityLevel = verbosity;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }
    }
}
