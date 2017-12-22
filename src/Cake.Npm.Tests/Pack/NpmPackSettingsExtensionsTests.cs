namespace Cake.Npm.Tests.Pack
{
    using Cake.Npm.Pack;
    using Shouldly;
    using Xunit;

    public sealed class NpmPackSettingsExtensionsTests
    {
        public sealed class TheFromSourceMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmPackSettings settings = null;

                // When
                var result = Record.Exception(() => settings.FromSource("foo"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Source_Is_Null()
            {
                // Given
                var settings = new NpmPackSettings();

                // When
                var result = Record.Exception(() => settings.FromSource(null));

                // Then
                result.IsArgumentNullException("source");
            }

            [Fact]
            public void Should_Throw_If_Source_Is_Empty()
            {
                // Given
                var settings = new NpmPackSettings();

                // When
                var result = Record.Exception(() => settings.FromSource(string.Empty));

                // Then
                result.IsArgumentNullException("source");
            }

            [Fact]
            public void Should_Throw_If_Source_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmPackSettings();

                // When
                var result = Record.Exception(() => settings.FromSource(" "));

                // Then
                result.IsArgumentNullException("source");
            }

            [Fact]
            public void Should_Set_Source()
            {
                // Given
                var settings = new NpmPackSettings();
                var source = "foo";

                // When
                settings.FromSource(source);

                // Then
                settings.Source.ShouldBe(source);
            }
        }
    }
}
