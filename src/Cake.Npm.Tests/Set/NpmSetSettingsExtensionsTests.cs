namespace Cake.Npm.Tests.Set
{
    using Cake.Npm.Set;
    using Shouldly;
    using Xunit;

    public sealed class NpmSetSettingsExtensionsTests
    {
        public sealed class TheForKeyMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmSetSettings settings = null;

                // When
                var result = Record.Exception(() => settings.ForKey("foo"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Key_Is_Null()
            {
                // Given
                var settings = new NpmSetSettings();

                // When
                var result = Record.Exception(() => settings.ForKey(null));

                // Then
                result.IsArgumentNullException("key");
            }

            [Fact]
            public void Should_Throw_If_Key_Is_Empty()
            {
                // Given
                var settings = new NpmSetSettings();

                // When
                var result = Record.Exception(() => settings.ForKey(string.Empty));

                // Then
                result.IsArgumentNullException("key");
            }

            [Fact]
            public void Should_Throw_If_Key_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmSetSettings();

                // When
                var result = Record.Exception(() => settings.ForKey(" "));

                // Then
                result.IsArgumentNullException("key");
            }

            [Fact]
            public void Should_Set_Key()
            {
                // Given
                var settings = new NpmSetSettings();
                var key = "foo";

                // When
                settings.ForKey(key);

                // Then
                settings.Key.ShouldBe(key);
            }
        }

        public sealed class TheWithValueMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmSetSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithValue("foo"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Value_Is_Null()
            {
                // Given
                var settings = new NpmSetSettings();

                // When
                var result = Record.Exception(() => settings.WithValue(null));

                // Then
                result.IsArgumentNullException("value");
            }

            [Fact]
            public void Should_Throw_If_Value_Is_Empty()
            {
                // Given
                var settings = new NpmSetSettings();

                // When
                var result = Record.Exception(() => settings.WithValue(string.Empty));

                // Then
                result.IsArgumentNullException("value");
            }

            [Fact]
            public void Should_Throw_If_Value_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmSetSettings();

                // When
                var result = Record.Exception(() => settings.WithValue(" "));

                // Then
                result.IsArgumentNullException("value");
            }

            [Fact]
            public void Should_Set_Value()
            {
                // Given
                var settings = new NpmSetSettings();
                var value = "foo";

                // When
                settings.WithValue(value);

                // Then
                settings.Value.ShouldBe(value);
            }
        }
    }
}
