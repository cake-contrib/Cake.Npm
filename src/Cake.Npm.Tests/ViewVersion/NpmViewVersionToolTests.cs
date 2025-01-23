namespace Cake.Npm.Tests.ViewVersion;

using Cake.Npm.ViewVersion;

using Shouldly;

using Xunit;

public class NpmViewVersionToolTests
{
    public sealed class TheViewVersionMethod
    {
        private readonly NpmViewVersionToolFixture fixture;

        public TheViewVersionMethod()
        {
            fixture = new NpmViewVersionToolFixture();
        }

        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            // Given
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Throw_If_Package_Is_Null()
        {
            // Given
            fixture.Settings.Package = null;

            // When
            var result = Record.Exception(() => fixture.Run());

            // Then
            result.IsArgumentOutOfRangeException("Package");
        }

        [Fact]
        public void Should_Throw_If_Extension_Is_Called_On_Null()
        {
            // Given
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => fixture.Settings.ForPackage("cakejs"));

            // Then
            result.IsArgumentNullException("settings");
        }

        [Fact]
        public void Should_Add_Mandatory_And_Default_Arguments()
        {
            // Given

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("view npm version", result.Args);
        }

        [Fact]
        public void Should_Add_Package_Argument()
        {
            // Given
            fixture.Settings.Package = "cakejs";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("view cakejs version", result.Args);
        }

        [Fact]
        public void Should_Add_Package_Argument_Using_Extension()
        {
            // Given
            fixture.Settings.ForPackage("cakejs");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("view cakejs version", result.Args);
        }

        [Fact]
        public void Should_Return_Version_From_StandardOutput()
        {
            const string version = "1.1.0";

            // Given
            fixture.ProcessRunner.Process.SetStandardOutput([version]);

            // When
            fixture.Run();

            // Then
            fixture.Version.ShouldBe(version);
        }
    }
}
