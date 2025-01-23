namespace Cake.Npm.Tests.Update;

using Cake.Npm.Update;
using Shouldly;
using Xunit;

public sealed class NpmUpdateSettingsExtensionsTests
{
    public sealed class TheUpdateGlobalPackagesMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmUpdateSettings settings = null;

            // When
            var result = Record.Exception(() => settings.UpdateGlobalPackages());

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Set_Global()
        {
            // Given
            var settings = new NpmUpdateSettings();

            // When
            settings.UpdateGlobalPackages();

            // Then
            settings.Global.ShouldBe(true);
        }
    }
}
