namespace Cake.Npm.Tests.Publish
{
    using System;
    using Cake.Npm.Publish;
    using Shouldly;
    using Xunit;

    public sealed class NpmPublishSettingsExtensionsTests
    {
        public sealed class TheFromSourceMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmPublishSettings settings = null;

                // When
                var result = Record.Exception(() => settings.FromSource("foo"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Source_Is_Null()
            {
                // Given
                var settings = new NpmPublishSettings();

                // When
                var result = Record.Exception(() => settings.FromSource(null));

                // Then
                result.IsArgumentNullException("source");
            }

            [Fact]
            public void Should_Throw_If_Source_Is_Empty()
            {
                // Given
                var settings = new NpmPublishSettings();

                // When
                var result = Record.Exception(() => settings.FromSource(string.Empty));

                // Then
                result.IsArgumentNullException("source");
            }

            [Fact]
            public void Should_Throw_If_Source_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmPublishSettings();

                // When
                var result = Record.Exception(() => settings.FromSource(" "));

                // Then
                result.IsArgumentNullException("source");
            }

            [Fact]
            public void Should_Set_Source()
            {
                // Given
                var settings = new NpmPublishSettings();
                var source = "foo";

                // When
                settings.FromSource(source);

                // Then
                settings.Source.ShouldBe(source);
            }

            [Fact]
            public void Should_Throw_If_Tag_Is_Null()
            {
                // Given
                var settings = new NpmPublishSettings();

                // When
                var result = Record.Exception(() => settings.WithTag(null));

                // Then
                result.IsArgumentNullException("tag");
            }

            [Fact]
            public void Should_Throw_If_Tag_Is_Empty()
            {
                // Given
                var settings = new NpmPublishSettings();

                // When
                var result = Record.Exception(() => settings.WithTag(string.Empty));

                // Then
                result.IsArgumentNullException("tag");
            }

            [Fact]
            public void Should_Throw_If_Tag_Is_WhiteSpace()
            {
                // Given
                var settings = new NpmPublishSettings();

                // When
                var result = Record.Exception(() => settings.WithTag(" "));

                // Then
                result.IsArgumentNullException("tag");
            }

            [Fact]
            public void Should_Set_Tag()
            {
                // Given
                var settings = new NpmPublishSettings();
                var tag = "1.2.3";

                // When
                settings.WithTag(tag);

                // Then
                settings.Tag.ShouldBe(tag);
            }

            [Fact]
            public void Should_Set_Access()
            {
                // Given
                var settings = new NpmPublishSettings();
                var access = NpmPublishAccess.Restricted;

                // When
                settings.WithAccess(access);

                // Then
                settings.Access.ShouldBe(access);
            }

            [Fact]
            public void Should_Throw_If_Registry_Is_Null()
            {
                // Given
                var settings = new NpmPublishSettings();

                // When
                var result = Record.Exception(() => settings.ToRegistry(null));

                // Then
                result.IsArgumentNullException("registry");
            }

            [Fact]
            public void Should_Set_Registry()
            {
                // Given
                var settings = new NpmPublishSettings();
                var registry = new Uri("https://example.com");

                // When
                settings.ToRegistry(registry);

                // Then
                settings.Registry.ShouldBe(registry);
            }
        }
    }
}
