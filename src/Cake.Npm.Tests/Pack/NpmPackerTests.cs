namespace Cake.Npm.Tests.Pack;

using Core.Diagnostics;
using Xunit;

public class NpmPackerTests
{
    public sealed class ThePackMethod
    {
        [Fact]
        public void Should_Redirect_Standard_Error()
        {
            var fixture = new NpmPackerFixture();
            fixture.Settings.RedirectStandardError = true;

            var result = fixture.Run();

            Assert.True(result.Process.RedirectStandardError);
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new NpmPackerFixture
            {
                Settings = null
            };

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Add_Mandatory_Arguments()
        {
            // Given
            var fixture = new NpmPackerFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("pack", result.Args);
        }

        [Fact]
        public void Should_Add_Source_To_Arguments_If_Not_Null()
        {
            // Given
            var fixture = new NpmPackerFixture();
            fixture.Settings.Source = "c:\\mypackage";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("pack \"c:\\mypackage\"", result.Args);
        }

        [Theory]
        [InlineData(NpmLogLevel.Default, "pack")]
        [InlineData(NpmLogLevel.Info, "pack --loglevel info")]
        [InlineData(NpmLogLevel.Silent, "pack --silent")]
        [InlineData(NpmLogLevel.Silly, "pack --loglevel silly")]
        [InlineData(NpmLogLevel.Verbose, "pack --loglevel verbose")]
        [InlineData(NpmLogLevel.Warn, "pack --warn")]
        public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
            NpmLogLevel logLevel,
            string expected)
        {
            // Given
            var fixture = new NpmPackerFixture();
            fixture.Settings.LogLevel = logLevel;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }

        [Theory]
        [InlineData(Verbosity.Diagnostic, "pack --loglevel verbose")]
        [InlineData(Verbosity.Minimal, "pack --warn")]
        [InlineData(Verbosity.Normal, "pack")]
        [InlineData(Verbosity.Quiet, "pack --silent")]
        [InlineData(Verbosity.Verbose, "pack --loglevel info")]
        public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
            Verbosity verbosity,
            string expected)
        {
            // Given
            var fixture = new NpmPackerFixture();
            fixture.Settings.CakeVerbosityLevel = verbosity;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }
    }
}
