namespace Cake.Npm.Tests.Prune;

using Cake.Npm.Prune;
using Core.Diagnostics;
using Xunit;

public class NpmPruneRunnerTests
{
    public sealed class ThePruneMethod
    {

        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new NpmPruneFixture
            {
                Settings = null
            };

            // When
            var result = Record.Exception(fixture.Run);

            // Then
            result.IsArgumentNullException("settings");
        }

        [Theory]
        [InlineData(NpmLogLevel.Default, "prune")]
        [InlineData(NpmLogLevel.Info, "prune --loglevel info")]
        [InlineData(NpmLogLevel.Silent, "prune --silent")]
        [InlineData(NpmLogLevel.Silly, "prune --loglevel silly")]
        [InlineData(NpmLogLevel.Verbose, "prune --loglevel verbose")]
        [InlineData(NpmLogLevel.Warn, "prune --warn")]
        public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
            NpmLogLevel logLevel,
            string expected)
        {
            // Given
            var fixture = new NpmPruneFixture { Settings = { LogLevel = logLevel } };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }

        [Theory]
        [InlineData(Verbosity.Diagnostic, "prune --loglevel verbose")]
        [InlineData(Verbosity.Minimal, "prune --warn")]
        [InlineData(Verbosity.Normal, "prune")]
        [InlineData(Verbosity.Quiet, "prune --silent")]
        [InlineData(Verbosity.Verbose, "prune --loglevel info")]
        public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
            Verbosity verbosity,
            string expected)
        {
            // Given
            var fixture = new NpmPruneFixture { Settings = { CakeVerbosityLevel = verbosity } };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }

        [Fact]
        public void Should_Add_DryRun_To_Args_If_True()
        {
            // Given
            var fixture = new NpmPruneFixture { Settings = { DryRun = true } };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("prune --dry-run", result.Args);
        }

        [Fact]
        public void Should_Add_Production_To_Args_If_True()
        {
            // Given
            var fixture = new NpmPruneFixture { Settings = { Production = true } };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("prune --production", result.Args);
        }

        [Fact]
        public void Should_Add_Json_To_Args_If_True()
        {
            // Given
            var fixture = new NpmPruneFixture { Settings = { Json = true } };

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("prune --json", result.Args);
        }

        [Theory]
        [InlineData("test1")]
        [InlineData("test1", "test2")]
        public void Should_Add_Packages_To_Args_If_NotEmpty(params string[] packages)
        {
            // Given
            var fixture = new NpmPruneFixture { Settings = new NpmPruneSettings() };
            foreach (var package in packages)
            {
                fixture.Settings.AddPackage(package);
            }

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal($"prune {string.Join(" ", packages)}", result.Args);
        }
    }
}
