using System;
using Cake.Core.Diagnostics;
using Cake.Npm.Rebuild;
using Xunit;

namespace Cake.Npm.Tests.Rebuild
{
    public class NpmRebuilderTests
    {
        public sealed class TheRebuildMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmRebuilderFixture {Settings = null};

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new NpmRebuilderFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("rebuild", result.Args);
            }

            [Fact]
            public void Should_Add_Packages_To_Arguments()
            {
                // Given
                var fixture = new NpmRebuilderFixture();
                fixture.Settings.AddPackage("foo");
                fixture.Settings.AddPackage("bar");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("rebuild foo bar", result.Args);
            }

            [Fact]
            public void Should_Add_Scoped_Package_To_Arguments()
            {
                // Given
                var fixture = new NpmRebuilderFixture();
                fixture.Settings.AddScopedPackage("foo", "@bar");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("rebuild @bar/foo", result.Args);
            }

            [Fact]
            public void Should_Throw_If_Scope_Does_Not_Start_With_At()
            {
                // Given
                var fixture = new NpmRebuilderFixture();

                // When
                var result = Record.Exception(() => fixture.Settings.AddScopedPackage("foo", "bar"));

                // Then
                Assert.IsType<ArgumentException>(result);
            }

            [Theory]
            [InlineData(NpmLogLevel.Default, "rebuild")]
            [InlineData(NpmLogLevel.Info, "rebuild --loglevel info")]
            [InlineData(NpmLogLevel.Silent, "rebuild --silent")]
            [InlineData(NpmLogLevel.Silly, "rebuild --loglevel silly")]
            [InlineData(NpmLogLevel.Verbose, "rebuild --loglevel verbose")]
            [InlineData(NpmLogLevel.Warn, "rebuild --warn")]
            [InlineData(NpmLogLevel.Error, "rebuild --loglevel error")]
            [InlineData(NpmLogLevel.Http, "rebuild --loglevel http")]
            public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
                NpmLogLevel logLevel,
                string expected)
            {
                // Given
                var fixture = new NpmRebuilderFixture();
                fixture.Settings.LogLevel = logLevel;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }

            [Theory]
            [InlineData(Verbosity.Diagnostic, "rebuild --loglevel verbose")]
            [InlineData(Verbosity.Minimal, "rebuild --warn")]
            [InlineData(Verbosity.Normal, "rebuild")]
            [InlineData(Verbosity.Quiet, "rebuild --silent")]
            [InlineData(Verbosity.Verbose, "rebuild --loglevel info")]
            public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
                Verbosity verbosity,
                string expected)
            {
                // Given
                var fixture = new NpmRebuilderFixture();
                fixture.Settings.CakeVerbosityLevel = verbosity;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal(expected, result.Args);
            }
        }
    }
}
