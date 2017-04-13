namespace Cake.Npm.Tests.RunScript
{
    using Core.Diagnostics;
    using Xunit;

    public class NpmScriptRunnerTests
    {
        public sealed class TheRunScriptMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmRunScriptFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Script_Name_Is_Null()
            {
                // Given
                var fixture = new NpmRunScriptFixture();
                fixture.Settings.ScriptName = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("ScriptName");
            }

            [Fact]
            public void Should_Add_ScriptName_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new NpmRunScriptFixture();
                fixture.Settings.ScriptName = "foo bar";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("run-script \"foo bar\"", result.Args);
            }

            [Fact]
            public void Should_Add_ScriptArguments_To_Arguments_If_Not_Empty()
            {
                // Given
                var fixture = new NpmRunScriptFixture();
                fixture.Settings.ScriptName = "hello";
                fixture.Settings.Arguments.Add("--foo=bar");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("run-script \"hello\" -- --foo=bar", result.Args);
            }

            [Theory]
            [InlineData(NpmLogLevel.Default, "run-script \"hello\"")]
            [InlineData(NpmLogLevel.Info, "run-script \"hello\" --loglevel info")]
            [InlineData(NpmLogLevel.Silent, "run-script \"hello\" --silent")]
            [InlineData(NpmLogLevel.Silly, "run-script \"hello\" --loglevel silly")]
            [InlineData(NpmLogLevel.Verbose, "run-script \"hello\" --loglevel verbose")]
            [InlineData(NpmLogLevel.Warn, "run-script \"hello\" --warn")]
            public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
                NpmLogLevel logLevel, 
                string expected)
            {
                // Given
                var fixture = new NpmRunScriptFixture();
                fixture.Settings.ScriptName = "hello";
                fixture.Settings.LogLevel = logLevel;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Theory]
            [InlineData(Verbosity.Diagnostic, "run-script \"hello\" --loglevel verbose")]
            [InlineData(Verbosity.Minimal, "run-script \"hello\" --warn")]
            [InlineData(Verbosity.Normal, "run-script \"hello\"")]
            [InlineData(Verbosity.Quiet, "run-script \"hello\" --silent")]
            [InlineData(Verbosity.Verbose, "run-script \"hello\" --loglevel info")]
            public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
                Verbosity verbosity,
                string expected)
            {
                // Given
                var fixture = new NpmRunScriptFixture();
                fixture.Settings.ScriptName = "hello";
                fixture.Settings.CakeVerbosityLevel = verbosity;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }
    }
}
