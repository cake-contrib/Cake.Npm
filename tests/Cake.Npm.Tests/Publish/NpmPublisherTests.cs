namespace Cake.Npm.Tests.Publish
{
    using System;
    using Core.Diagnostics;
    using Xunit;

    public class NpmPublisherTests
    {
        public sealed class ThePublishMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmPublisherFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new NpmPublisherFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish", result.Args);
            }

            [Fact]
            public void Should_Add_Source_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new NpmPublisherFixture();
                fixture.Settings.Source = "c:\\mypackage";

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish \"c:\\mypackage\"", result.Args);
            }

            [Fact]
            public void Should_Add_Registry_To_Arguments_If_Not_Null()
            {
                // Given
                var fixture = new NpmPublisherFixture();
                fixture.Settings.Registry = new Uri("https://example.com");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("publish --registry https://example.com/", result.Args);
            }

            [Theory]
            [InlineData(NpmLogLevel.Default, "publish")]
            [InlineData(NpmLogLevel.Info, "publish --loglevel info")]
            [InlineData(NpmLogLevel.Silent, "publish --silent")]
            [InlineData(NpmLogLevel.Silly, "publish --loglevel silly")]
            [InlineData(NpmLogLevel.Verbose, "publish --loglevel verbose")]
            [InlineData(NpmLogLevel.Warn, "publish --warn")]
            public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
                NpmLogLevel logLevel, 
                string expected)
            {
                // Given
                var fixture = new NpmPublisherFixture();
                fixture.Settings.LogLevel = logLevel;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Theory]
            [InlineData(Verbosity.Diagnostic, "publish --loglevel verbose")]
            [InlineData(Verbosity.Minimal, "publish --warn")]
            [InlineData(Verbosity.Normal, "publish")]
            [InlineData(Verbosity.Quiet, "publish --silent")]
            [InlineData(Verbosity.Verbose, "publish --loglevel info")]
            public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
                Verbosity verbosity,
                string expected)
            {
                // Given
                var fixture = new NpmPublisherFixture();
                fixture.Settings.CakeVerbosityLevel = verbosity;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }
    }
}
