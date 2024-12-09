namespace Cake.Npm.Tests.Ci
{
    using System;
    using Cake.Core.Diagnostics;
    using Cake.Npm.Ci;
    using Xunit;

    public class NpmCiToolTests
    {
        public sealed class TheAutomatedInstallMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new NpmCiToolFixture();
                fixture.Settings.RedirectStandardError = true;

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmCiToolFixture
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
                var fixture = new NpmCiToolFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("ci", result.Args);
            }

            [Theory]
            [InlineData(NpmLogLevel.Default, "ci")]
            [InlineData(NpmLogLevel.Info, "ci --loglevel info")]
            [InlineData(NpmLogLevel.Silent, "ci --silent")]
            [InlineData(NpmLogLevel.Silly, "ci --loglevel silly")]
            [InlineData(NpmLogLevel.Verbose, "ci --loglevel verbose")]
            [InlineData(NpmLogLevel.Warn, "ci --warn")]
            [InlineData(NpmLogLevel.Error, "ci --loglevel error")]
            [InlineData(NpmLogLevel.Http, "ci --loglevel http")]
            public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
                NpmLogLevel logLevel,
                string expected)
            {
                // Given
                var fixture = new NpmCiToolFixture();
                fixture.Settings.LogLevel = logLevel;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Theory]
            [InlineData(Verbosity.Diagnostic, "ci --loglevel verbose")]
            [InlineData(Verbosity.Minimal, "ci --warn")]
            [InlineData(Verbosity.Normal, "ci")]
            [InlineData(Verbosity.Quiet, "ci --silent")]
            [InlineData(Verbosity.Verbose, "ci --loglevel info")]
            public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
                Verbosity verbosity,
                string expected)
            {
                // Given
                var fixture = new NpmCiToolFixture();
                fixture.Settings.CakeVerbosityLevel = verbosity;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Fact]
            public void Should_Include_Production_Flag()
            {
                // Given
                var fixture = new NpmCiToolFixture();
                fixture.Settings.ForProduction();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("ci --production", result.Args);
            }


	        [Fact]
	        public void Should_Include_Registry_Args_If_Set()
	        {
		        // Given
		        var fixture = new NpmCiToolFixture();
		        fixture.Settings.FromRegistry(new Uri("https://myregistry/"));

		        // When
		        var result = fixture.Run();

		        // Then
		        Assert.Equal("ci --registry https://myregistry/", result.Args);
	        }
		}
    }
}
