namespace Cake.Npm.Tests.Install;

using System;
using Cake.Core.Diagnostics;
using Xunit;
using Cake.Npm.Install;

public class NpmInstallerTests
{
    public sealed class TheInstallMethod
    {
        [Fact]
        public void Should_Redirect_Standard_Error()
        {
            var fixture = new NpmInstallerFixture();
            fixture.Settings.RedirectStandardError = true;

            var result = fixture.Run();

            Assert.True(result.Process.RedirectStandardError);
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            var fixture = new NpmInstallerFixture
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
            var fixture = new NpmInstallerFixture();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install", result.Args);
        }

        [Fact]
        public void Should_Add_Package_Url_To_Arguments()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.AddPackage(new Uri("https://www.example.com/mypackage.tgz"));

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install https://www.example.com/mypackage.tgz", result.Args);
        }

        [Fact]
        public void Should_Throw_If_Not_Absolute_Uri()
        {
            // Given
            var fixture = new NpmInstallerFixture();

            // When
            var result = Record.Exception(
                () => 
                    fixture.Settings.AddPackage(
                        new Uri("https://www.example.com/foo/mypackage.tgz").MakeRelativeUri(new Uri("https://www.example.com"))));

            // Then
            Assert.IsType<UriFormatException>(result);
        }

        [Fact]
        public void Should_Add_Packages_To_Arguments()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.AddPackage("foo");
            fixture.Settings.AddPackage("bar");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install foo bar", result.Args);
        }

        [Fact]
        public void Should_Add_Package_With_Version_To_Arguments()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.AddPackage("foo", "1.2.3");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install foo@1.2.3", result.Args);
        }

        [Fact]
        public void Should_Add_Package_With_Tag_To_Arguments()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.AddPackage("foo", "bar");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install foo@bar", result.Args);
        }

        [Fact]
        public void Should_Add_Package_With_Tag_Containing_Space_To_Arguments()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.AddPackage("foo", "bar bla");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install foo@\"bar bla\"", result.Args);
        }

        [Fact]
        public void Should_Add_Scoped_Package_To_Arguments()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.AddScopedPackage("foo", "@bar");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install @bar/foo", result.Args);
        }

        [Fact]
        public void Should_Throw_If_Scope_Does_Not_Start_With_At()
        {
            // Given
            var fixture = new NpmInstallerFixture();

            // When
            var result = Record.Exception(() => fixture.Settings.AddScopedPackage("foo", "bar"));

            // Then
            Assert.IsType<ArgumentException>(result);
        }

        [Fact]
        public void Should_Add_Force_To_Arguments_If_Not_Null()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.Force = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install --force", result.Args);
        }

        [Fact]
        public void Should_Add_NoOptional_To_Arguments_If_Specified()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.NoOptional = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install --no-optional", result.Args);
        }

        [Fact]
        public void Should_Add_Global_To_Arguments_If_Not_Null()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.Global = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install --global", result.Args);
        }

        [Fact]
        public void Should_Add_PreferOffline_To_Arguments_If_Not_Null()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.PreferOffline = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install --prefer-offline", result.Args);
        }

        [Fact]
        public void Should_Add_Registry_To_Arguments_If_Set()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            var registry = new Uri("http://exampleregistry.com");
            fixture.Settings.Registry = registry;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal($"install --registry { registry }", result.Args);
        }

        [Fact]
        public void Should_Not_Add_Registry_To_Arguments_If_Not_Set()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.Registry = null;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install", result.Args);
        }

        [Fact]
        public void Should_Add_Production_To_Arguments_If_Not_Null()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.Production = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("install --production", result.Args);
        }

        [Fact]
        public void Should_Throw_If_Production_Is_Used_Together_With_Packages()
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.Production = true;
            fixture.Settings.Packages.Add("foo");

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            Assert.IsType<NotSupportedException>(result);
        }

        [Theory]
        [InlineData(NpmLogLevel.Default, "install")]
        [InlineData(NpmLogLevel.Info, "install --loglevel info")]
        [InlineData(NpmLogLevel.Silent, "install --silent")]
        [InlineData(NpmLogLevel.Silly, "install --loglevel silly")]
        [InlineData(NpmLogLevel.Verbose, "install --loglevel verbose")]
        [InlineData(NpmLogLevel.Warn, "install --warn")]
        [InlineData(NpmLogLevel.Error, "install --loglevel error")]
        [InlineData(NpmLogLevel.Http, "install --loglevel http")]
        public void Should_Add_LogLevel_To_Arguments_If_Not_Null(
            NpmLogLevel logLevel,
            string expected)
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.LogLevel = logLevel;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }

        [Theory]
        [InlineData(Verbosity.Diagnostic, "install --loglevel verbose")]
        [InlineData(Verbosity.Minimal, "install --warn")]
        [InlineData(Verbosity.Normal, "install")]
        [InlineData(Verbosity.Quiet, "install --silent")]
        [InlineData(Verbosity.Verbose, "install --loglevel info")]
        public void Should_Use_Cake_LogLevel_If_LogLevel_Is_Set_To_Default(
            Verbosity verbosity,
            string expected)
        {
            // Given
            var fixture = new NpmInstallerFixture();
            fixture.Settings.CakeVerbosityLevel = verbosity;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal(expected, result.Args);
        }
    }
}
