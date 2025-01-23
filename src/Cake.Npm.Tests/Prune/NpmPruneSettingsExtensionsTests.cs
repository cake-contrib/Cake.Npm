namespace Cake.Npm.Tests.Prune;

using Cake.Npm.Prune;
using Shouldly;
using Xunit;

public sealed class NpmPruneSettingsExtensionsTests
{
    public sealed class TheForProductionMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmPruneSettings settings = null;

            // When
            var result = Record.Exception(settings.ForProduction);

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Set_Production_Flag_True_()
        {
            // Given
            NpmPruneSettings settings = new();

            // When
            settings.ForProduction();

            // Then
            settings.Production.ShouldBe(true);
        }

        [Fact]
        public void Should_Set_Production_Flag_False()
        {
            // Given
            NpmPruneSettings settings = new() { Production = true };

            // When
            settings.ForProduction(false);

            // Then
            settings.Production.ShouldBe(false);
        }
    }
    public sealed class TheAddPackageMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmPruneSettings settings = null;

            // When
            var result = Record.Exception(() => settings.AddPackage("test"));

            // Then
            result.IsArgumentNullException("settings");
        }

        [Theory]
        [InlineData("")]
        [InlineData("\n \t")]
        [InlineData(null)]
        public void Should_Throw_If_PackageName_Is_Null_Or_Whitespace(string packageName)
        {
            // Given
            NpmPruneSettings settings = new();

            // When
            var result = Record.Exception(() => settings.AddPackage(packageName));

            // Then
            result.IsArgumentNullException("packageName");
        }

        [Fact]
        public void Should_Throw_If_Scope_Does_Not_Start_With_At_Symbol()
        {
            // Given
            NpmPruneSettings settings = new();

            // When
            var result = Record.Exception(() => settings.AddPackage("test", "badscope"));

            // Then
            result.IsArgumentException("scope");
        }

        [Fact]
        public void Should_Add_PackageName_To_Packages()
        {
            // Given
            NpmPruneSettings settings = new();

            // When
            settings.AddPackage("test");

            // Then
            settings.Packages.ShouldContain("test");
        }

        [Fact]
        public void Should_Add_PackageName_And_Scope_To_Packages()
        {
            // Given
            NpmPruneSettings settings = new();

            // When
            settings.AddPackage("test", "@scope");

            // Then
            settings.Packages.ShouldContain("@scope/test");
        }
    }
    public sealed class TheDryRunMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmPruneSettings settings = null;

            // When
            var result = Record.Exception(() => settings.DryRun());

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Set_DryRun_Flag_True_()
        {
            // Given
            NpmPruneSettings settings = new();

            // When
            settings.DryRun();

            // Then
            settings.DryRun.ShouldBe(true);
        }

        [Fact]
        public void Should_Set_DryRun_Flag_False()
        {
            // Given
            NpmPruneSettings settings = new() { DryRun = true };

            // When
            settings.DryRun(false);

            // Then
            settings.DryRun.ShouldBe(false);
        }
    }
    public sealed class TheJsonMethod
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            NpmPruneSettings settings = null;

            // When
            var result = Record.Exception(() => settings.Json());

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Set_Json_Flag_True_()
        {
            // Given
            NpmPruneSettings settings = new();

            // When
            settings.Json();

            // Then
            settings.Json.ShouldBe(true);
        }

        [Fact]
        public void Should_Set_Json_Flag_False()
        {
            // Given
            NpmPruneSettings settings = new() { Json = true };

            // When
            settings.Json(false);

            // Then
            settings.Json.ShouldBe(false);
        }
    }
}
