﻿namespace Cake.Npm.Tests.RunScript
{
    using Core.Diagnostics;
    using Xunit;

    public class NpmScriptRunnerTests
    {
        public sealed class TheRunScriptMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new NpmRunScriptFixture();
                fixture.Settings.RedirectStandardError = true;
                fixture.Settings.ScriptName = "foo bar";

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmRunScriptFixture
                {
                    Settings = null
                };

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
            [InlineData(NpmLogLevel.Info, "run-script --loglevel info \"hello\"")]
            [InlineData(NpmLogLevel.Silent, "run-script --silent \"hello\"")]
            [InlineData(NpmLogLevel.Silly, "run-script --loglevel silly \"hello\"")]
            [InlineData(NpmLogLevel.Verbose, "run-script --loglevel verbose \"hello\"")]
            [InlineData(NpmLogLevel.Warn, "run-script --warn \"hello\"")]
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
            [InlineData(Verbosity.Diagnostic, "run-script --loglevel verbose \"hello\"")]
            [InlineData(Verbosity.Minimal, "run-script --warn \"hello\"")]
            [InlineData(Verbosity.Normal, "run-script \"hello\"")]
            [InlineData(Verbosity.Quiet, "run-script --silent \"hello\"")]
            [InlineData(Verbosity.Verbose, "run-script --loglevel info \"hello\"")]
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
