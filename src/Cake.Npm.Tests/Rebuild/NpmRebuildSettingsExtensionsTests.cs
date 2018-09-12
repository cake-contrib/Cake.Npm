namespace Cake.Npm.Tests.Rebuild
{
    using Cake.Npm.Rebuild;
    using Shouldly;
    using Xunit;

    public sealed class NpmRebuildSettingsExtensionsTests
    {
        public sealed class TheAddPackageMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmRebuildSettings settings = null;

                // When
                var result = Record.Exception(() => settings.AddPackage("foo"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Null()
            {
                // Given
                var settings = new NpmRebuildSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage((string)null));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Empty()
            {
                // Given
                var settings = new NpmRebuildSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(string.Empty));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmRebuildSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(" "));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Add_Package()
            {
                // Given
                var settings = new NpmRebuildSettings();
                var packageName = "foo";

                // When
                settings.AddPackage(packageName);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName);
            }
        }

        public sealed class TheAddScopedPackageMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmRebuildSettings settings = null;

                // When
                var result = Record.Exception(() => settings.AddScopedPackage("foo", "@bar"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Null()
            {
                // Given
                var settings = new NpmRebuildSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage(null, "@bar"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Empty()
            {
                // Given
                var settings = new NpmRebuildSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage(string.Empty, "@bar"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmRebuildSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage(" ", "@bar"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Scope_Does_Not_Start_With_At()
            {
                // Given
                var settings = new NpmRebuildSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage("foo", "bar"));

                // Then
                result.IsArgumentException("scope");
            }

            [Fact]
            public void Should_Add_Package()
            {
                // Given
                var settings = new NpmRebuildSettings();
                var packageName = "foo";
                var scope = "@bar";

                // When
                settings.AddScopedPackage(packageName, scope);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(scope + "/" + packageName);
            }

            [Fact]
            public void Should_Add_Package_If_Scope_Is_Null()
            {
                // Given
                var settings = new NpmRebuildSettings();
                var packageName = "foo";
                string scope = null;

                // When
                settings.AddScopedPackage(packageName, scope);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName);
            }

            [Fact]
            public void Should_Add_Package_If_Scope_Is_Empty()
            {
                // Given
                var settings = new NpmRebuildSettings();
                var packageName = "foo";
                var scope = string.Empty;

                // When
                settings.AddScopedPackage(packageName, scope);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName);
            }

            [Fact]
            public void Should_Add_Package_If_Scope_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmRebuildSettings();
                var packageName = "foo";
                var scope = " ";

                // When
                settings.AddScopedPackage(packageName, scope);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName);
            }
        }
    }
}
