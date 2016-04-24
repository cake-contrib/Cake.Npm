using System;
using Cake.Core;
using Cake.Testing;
using Shouldly;
using Xunit;

namespace Cake.Npm.Tests.Package
{
	public class NpmPackageTests
	{
        public sealed class TheConstructor
        {
            [Fact]
            public void Should_Throw_If_File_System_Is_Null()
            {
                // Given
                var environment = FakeEnvironment.CreateUnixEnvironment();

                // When
                var result = Record.Exception(() => new NpmPackageParser(null, environment));

                // Then
                Assert.IsType<ArgumentNullException>(result);
            }

            [Fact]
            public void Should_Throw_If_Environment_Is_Null()
            {
                // Given
                var environment = FakeEnvironment.CreateUnixEnvironment();
                var fileSystem = new FakeFileSystem(environment);

                // When
                var result = Record.Exception(() => new NpmPackageParser(fileSystem, null));

                // Then
                Assert.IsType<ArgumentNullException>(result);
            }
        }

        [Fact]
	    public void Should_Throw_When_No_File_Found()
	    {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = Record.Exception(() => fixture.Parse("./Non-Existent-File.json"));

            // Then
            Assert.IsType<CakeException>(result);
	    }

        [Fact]
        public void Should_Allow_Relative_Path()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse("./package.json");

            // Then
            result.ShouldNotBeNull();
        }

	    [Fact]
	    public void Should_Parse_Package_File()
	    {
            // Given
            var fixture = new NpmPackageFixture();

            // When
	        var result = fixture.Parse();

            // Then
            result.ShouldNotBeNull();
        }

	    [Fact]
	    public void Should_Parse_Package_Name()
	    {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.Name.ShouldBe("module-name");
        }

	    [Fact]
	    public void Should_Parse_Package_Version()
	    {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.Version.ShouldBe("10.3.1");
        }

        [Fact]
        public void Should_Parse_Package_Description()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.Description.ShouldBe("An example module to illustrate the usage of a package.json");
        }

        [Fact]
        public void Should_Parse_Package_Author()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.Author.ShouldBe("Your Name <you.name@example.org>");
        }

        [Fact]
        public void Should_Parse_Package_Entry_Point()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.EntryPoint.ShouldBe("lib/foo.js");
        }

        [Fact]
        public void Should_Parse_Package_Privacy()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.IsPrivate.ShouldBe(true);
        }

        [Fact]
        public void Should_Parse_Package_License()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.License.ShouldBe("MIT");
        }

        [Fact]
        public void Should_Parse_Package_Keywords()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.Keywords.Count.ShouldBe(3);
            result.Keywords.ShouldBe(new [] {"nodejitsu", "example", "browsenpm" }, ignoreOrder: true);
        }

        [Fact]
        public void Should_Parse_Package_Scripts()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.Scripts.Count.ShouldBe(3);

            // Then
            result.Scripts.ShouldContainKeyAndValue("start", "node index.js");
            result.Scripts.ShouldContainKeyAndValue("test", "vows --spec --isolate");
            result.Scripts.ShouldContainKeyAndValue("prepublish", "coffee --bare --compile --output lib/foo src/foo/*.coffee");
        }

        [Fact]
        public void Should_Parse_Package_Dependencies()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.Dependencies.Count.ShouldBe(6);
            result.Dependencies.ShouldContainKeyAndValue("async", "~0.8.0");
        }

        [Fact]
        public void Should_Parse_Package_Dev_Dependencies()
        {
            // Given
            var fixture = new NpmPackageFixture();

            // When
            var result = fixture.Parse();

            // Then
            result.DevelopmentDependencies.Count.ShouldBe(3);
            result.DevelopmentDependencies.ShouldContainKeyAndValue("assume", "<1.0.0 || >=2.3.1 <2.4.5 || >=2.5.2 <3.0.0");
        }
	}
}
