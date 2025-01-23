namespace Cake.Npm.Tests.AddUser;

using System;
using Cake.Npm.AddUser;
using Shouldly;
using Xunit;

public sealed class NpmAddUserSettingsExtensionsTests
{
    public sealed class TheFromRegistryMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmAddUserSettings settings = null;
            Uri registry = new("https://myregistry.com");

            // When
            var result = Record.Exception(() => settings.ForRegistry(registry));

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Throw_If_Registry_Is_Null()
        {
            // Given
            var settings = new NpmAddUserSettings();
            Uri registry = null;

            // When
            var result = Record.Exception(() => settings.ForRegistry(registry));

            // Then
            result.IsArgumentNullException("registry");
        }

        [Fact]
        public void Should_Set_Registry()
        {
            // Given
            var settings = new NpmAddUserSettings();
            Uri registry = new("https://myregistry.com");

            // When
            var result = settings.ForRegistry(registry);

            // Then
            result.Registry.ShouldBe(registry);
        }
    }

    public sealed class TheAddScopeMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmAddUserSettings settings = null;

            // When
            var result = Record.Exception(() => settings.ForScope("@bar"));

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Throw_If_Scope_Is_Null()
        {
            // Given
            var settings = new NpmAddUserSettings();

            // When
            var result = Record.Exception(() => settings.ForScope(null));

            // Then
            result.IsArgumentNullException("scope");
        }

        [Fact]
        public void Should_Throw_If_Scope_Is_Empty()
        {
            // Given
            var settings = new NpmAddUserSettings();

            // When
            var result = Record.Exception(() => settings.ForScope(string.Empty));

            // Then
            result.IsArgumentNullException("scope");
        }

        [Fact]
        public void Should_Throw_If_Scope_Is_WhiteSpace()
        {
            // Given
            var settings = new NpmAddUserSettings();

            // When
            var result = Record.Exception(() => settings.ForScope(" "));

            // Then
            result.IsArgumentNullException("scope");
        }

        [Fact]
        public void Should_Throw_If_Scope_Does_Not_Start_With_At()
        {
            // Given
            var settings = new NpmAddUserSettings();

            // When
            var result = Record.Exception(() => settings.ForScope("bar"));

            // Then
            result.IsArgumentException("scope");
        }

        [Fact]
        public void Should_Set_Scope()
        {
            // Given
            var settings = new NpmAddUserSettings();

            // When
            settings.ForScope("@bar");

            // Then
            Assert.Equal("@bar", settings.Scope);
        }
    }

    public sealed class TheAddAlwaysAuthMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmAddUserSettings settings = null;

            // When
            var result = Record.Exception(() => settings.AlwaysAuthenticate());

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Set_AlwaysAuth_To_True()
        {
            // Given
            var settings = new NpmAddUserSettings();

            // When
            settings.AlwaysAuthenticate();

            // Then
            Assert.True(settings.AlwaysAuth);
        }
    }

    public sealed class TheAddAuthTypeMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmAddUserSettings settings = null;

            // When
            var result = Record.Exception(() => settings.UsingAuthentication(AuthType.Legacy));

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Set_AuthType_To_Legacy_Settings()
        {
            // Given
            var settings = new NpmAddUserSettings();

            // When
            settings.UsingAuthentication(AuthType.Legacy);

            // Then
            Assert.Equal(AuthType.Legacy, settings.AuthType);
        }
    }
}
