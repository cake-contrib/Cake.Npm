namespace Cake.Npm.Tests
{
    using System;

    using Cake.Npm.Install;
    using Shouldly;
    using Xunit;

    public sealed class NpmSettingsExtensionsTests
    {
        public sealed class TheWithLogLevelMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithLogLevel(NpmLogLevel.Default));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Theory]
            [InlineData(NpmLogLevel.Default)]
            [InlineData(NpmLogLevel.Error)]
            [InlineData(NpmLogLevel.Http)]
            [InlineData(NpmLogLevel.Info)]
            [InlineData(NpmLogLevel.Silent)]
            [InlineData(NpmLogLevel.Silly)]
            [InlineData(NpmLogLevel.Verbose)]
            [InlineData(NpmLogLevel.Warn)]
            public void Should_Set_LogLevel(NpmLogLevel logLevel)
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                settings.WithLogLevel(logLevel);

                // Then
                settings.LogLevel.ShouldBe(logLevel);
            }
        }

        public sealed class TheFromPathMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmSettings settings = null;

                // When
                var result = Record.Exception(() => settings.FromPath(@"c:\temp"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Path_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.FromPath(null));

                // Then
                result.IsArgumentNullException("path");
            }

            [Fact]
            public void Should_Set_WorkingDirectory()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                settings.FromPath(@"c:\temp");

                // Then
                settings.WorkingDirectory.ToString().ShouldBe(@"c:/temp");
            }

            [Fact]
            public void Should_Set_StandardOutputAction()
            {
                // Given
                var settings = new NpmInstallSettings();
                Action<string> action = x => { };

                // When
                settings.SetRedirectedStandardOutputHandler(action);

                // Then
                settings.StandardOutputAction.ShouldBe(action);
            }

            [Fact]
            public void Should_Set_StandardErrorAction()
            {
                // Given
                var settings = new NpmInstallSettings();
                Action<string> action = x => { };

                // When
                settings.SetRedirectedStandardErrorHandler(action);

                // Then
                settings.StandardErrorAction.ShouldBe(action);
            }
        }
    }
}
