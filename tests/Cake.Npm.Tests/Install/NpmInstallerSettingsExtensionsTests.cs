namespace Cake.Npm.Tests.Install
{
    using System;
    using Cake.Npm.Install;
    using Shouldly;
    using Xunit;

    public sealed class NpmInstallSettingsExtensionsTests
    {
        public sealed class TheWithForceMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithForce());

                // Then
                result.IsArgumentNullException("settings");
            }
            [Fact]
            public void Should_Set_Force()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                settings.WithForce();

                // Then
                settings.Force.ShouldBe(true);
            }
        }

        public sealed class TheWithouthForceMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithoutForce());

                // Then
                result.IsArgumentNullException("settings");
            }
            [Fact]
            public void Should_Set_Force()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                settings.WithoutForce();

                // Then
                settings.Force.ShouldBe(false);
            }
        }

        public sealed class TheInstallGloballyMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.InstallGlobally());

                // Then
                result.IsArgumentNullException("settings");
            }
            [Fact]
            public void Should_Set_Global()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                settings.InstallGlobally();

                // Then
                settings.Global.ShouldBe(true);
            }
        }

        public sealed class TheInstallLocallyMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.InstallLocally());

                // Then
                result.IsArgumentNullException("settings");
            }
            [Fact]
            public void Should_Set_Global()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                settings.InstallLocally();

                // Then
                settings.Global.ShouldBe(false);
            }
        }

        public sealed class TheForProductionMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.ForProduction());

                // Then
                result.IsArgumentNullException("settings");
            }
            [Fact]
            public void Should_Set_Production()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                settings.ForProduction();

                // Then
                settings.Production.ShouldBe(true);
            }
        }

        public sealed class TheAddPackageByUriMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.AddPackage(new Uri("http://example.com")));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Uri_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage((Uri)null));

                // Then
                result.IsArgumentNullException("url");
            }

            [Fact]
            public void Should_Throw_If_Uri_Is_Not_Absolute()
            {
                // Given
                var settings = new NpmInstallSettings();
                var url1 = new Uri("http://example.com/foo");
                var url2 = new Uri("http://example.com");
                var url = url2.MakeRelativeUri(url1);

                // When
                var result = Record.Exception(() => settings.AddPackage(url));

                // Then
                result.IsUriFormatException();
            }

            [Fact]
            public void Should_Add_Package()
            {
                // Given
                var settings = new NpmInstallSettings();
                var url = new Uri("http://example.com");

                // When
                settings.AddPackage(url);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(url.ToString());
            }
        }

        public sealed class TheAddPackageByNameMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.AddPackage("foo"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage((string)null));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(string.Empty));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(" "));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Add_Package()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";

                // When
                settings.AddPackage(packageName);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName);
            }
        }

        public sealed class TheAddPackageByNameAndVersionMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.AddPackage("foo", "1.0"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(null, "1.0"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(string.Empty, "1.0"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(" ", "1.0"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Version_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage("foo", null));

                // Then
                result.IsArgumentNullException("versionOrTag");
            }

            [Fact]
            public void Should_Throw_If_Version_Is_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage("foo", string.Empty));

                // Then
                result.IsArgumentNullException("versionOrTag");
            }

            [Fact]
            public void Should_Throw_If_Version_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage("foo", " "));

                // Then
                result.IsArgumentNullException("versionOrTag");
            }

            [Fact]
            public void Should_Add_Package()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var version = "1.0";

                // When
                settings.AddPackage(packageName, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName + "@" + version);
            }

            [Fact]
            public void Should_Quote_If_Tag_Contains_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var tag = "foo bar";

                // When
                settings.AddPackage(packageName, tag);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName + "@\"" + tag + "\"");
            }
        }

        public sealed class TheAddScopedPackageMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.AddScopedPackage("foo", "@bar"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage(null, "@bar"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage(string.Empty, "@bar"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage(" ", "@bar"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Scope_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage("foo", null));

                // Then
                result.IsArgumentNullException("scope");
            }

            [Fact]
            public void Should_Throw_If_Scope_Is_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage("foo", string.Empty));

                // Then
                result.IsArgumentNullException("scope");
            }

            [Fact]
            public void Should_Throw_If_Scope_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage("foo", " "));

                // Then
                result.IsArgumentNullException("scope");
            }

            [Fact]
            public void Should_Throw_If_Scope_Does_Not_Start_With_At()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddScopedPackage("foo", "bar"));

                // Then
                result.IsArgumentException("scope");
            }

            [Fact]
            public void Should_Add_Package()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var scope = "@bar";

                // When
                settings.AddScopedPackage(packageName, scope);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(scope + "/" + packageName);
            }
        }

        public sealed class TheAddPackageByNameAndScopeAndVersionMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.AddPackage("foo", "@bar", "1.0.0"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Null()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(null, "@bar", "1.0.0"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(string.Empty, "@bar", "1.0.0"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Throw_If_Package_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage(" ", "@bar", "1.0.0"));

                // Then
                result.IsArgumentNullException("packageName");
            }

            [Fact]
            public void Should_Ignore_Scope_If_Null()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var version = "1.0.0";
                string scope = null;

                // When
                settings.AddPackage(packageName, scope, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName + "@" + version);
            }

            [Fact]
            public void Should_Ignore_Scope_If_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var version = "1.0.0";
                var scope = string.Empty;

                // When
                settings.AddPackage(packageName, scope, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName + "@" + version);
            }

            [Fact]
            public void Should_Ignore_Scope_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var version = "1.0.0";
                var scope = " ";

                // When
                settings.AddPackage(packageName, scope, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(packageName + "@" + version);
            }

            [Fact]
            public void Should_Throw_If_Scope_Does_Not_Start_With_At()
            {
                // Given
                var settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.AddPackage("foo", "bar", "1.0.0"));

                // Then
                result.IsArgumentException("scope");
            }

            [Fact]
            public void Should_Ignore_Version_If_Null()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var scope = "@bar";
                string version = null;

                // When
                settings.AddPackage(packageName, scope, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(scope + "/" + packageName);
            }

            [Fact]
            public void Should_Ignore_Version_If_Empty()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var scope = "@bar";
                var version = string.Empty;

                // When
                settings.AddPackage(packageName, scope, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(scope + "/" + packageName);
            }

            [Fact]
            public void Should_Ignore_Version_If_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var scope = "@bar";
                var version = " ";

                // When
                settings.AddPackage(packageName, scope, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(scope + "/" + packageName);
            }

            [Fact]
            public void Should_Add_Package()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var version = "1.0.0";
                var scope = "@bar";

                // When
                settings.AddPackage(packageName, scope, version);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(scope + "/" + packageName + "@" + version);
            }

            [Fact]
            public void Should_Quote_If_Tag_Contains_WhiteSpace()
            {
                // Given
                var settings = new NpmInstallSettings();
                var packageName = "foo";
                var tag = "foo bar";
                var scope = "@bar";

                // When
                settings.AddPackage(packageName, scope, tag);

                // Then
                settings.Packages.Count.ShouldBe(1);
                settings.Packages.ShouldContain(scope + "/" + packageName + "@\"" + tag + "\"");
            }
        }

        public sealed class TheWithNpmArgumentsMethod
        {
            [Fact]
            public void Should_Add_Argument()
            {
                // Given
                NpmInstallSettings settings = new NpmInstallSettings();

                // When
                settings.WithNpmArguments("--no-color");

                // Then
                settings.NpmArguments.ShouldContain("--no-color");
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmInstallSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithNpmArguments("--no-color"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Args_Are_Null()
            {
                // Given
                NpmInstallSettings settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.WithNpmArguments(null));

                // Then
                result.IsArgumentNullException("arguments");
            }

            [Fact]
            public void Should_Throw_If_Args_Are_Whitespace()
            {
                // Given
                NpmInstallSettings settings = new NpmInstallSettings();

                // When
                var result = Record.Exception(() => settings.WithNpmArguments(" "));

                // Then
                result.IsArgumentNullException("arguments");
            }
        }
    }
}
