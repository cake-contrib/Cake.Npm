using Cake.Npm.RunScript;
using Shouldly;
using Xunit;

namespace Cake.Npm.Tests.Exec
{
    public sealed class NpmExecSettingsExtensionsTests
    {
        public sealed class TheWithArgumentsMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                NpmRunScriptSettings settings = null;

                // When
                var result = Record.Exception(() => settings.WithArguments("foo"));

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Throw_If_Arguments_Are_Null()
            {
                // Given
                var settings = new NpmRunScriptSettings();

                // When
                var result = Record.Exception(() => settings.WithArguments(null));

                // Then
                result.IsArgumentNullException("arguments");
            }

            [Fact]
            public void Should_Throw_If_Arguments_Are_Empty()
            {
                // Given
                var settings = new NpmRunScriptSettings();

                // When
                var result = Record.Exception(() => settings.WithArguments(string.Empty));

                // Then
                result.IsArgumentNullException("arguments");
            }

            [Fact]
            public void Should_Throw_If_Arguments_Are_WhiteSpace()
            {
                // Given
                var settings = new NpmRunScriptSettings();

                // When
                var result = Record.Exception(() => settings.WithArguments(" "));

                // Then
                result.IsArgumentNullException("arguments");
            }

            [Fact]
            public void Should_Set_Arguments()
            {
                // Given
                var settings = new NpmRunScriptSettings();
                var arguments = "foo";

                // When
                settings.WithArguments(arguments);

                // Then
                settings.Arguments.Count.ShouldBe(1);
                settings.Arguments.ShouldContain(arguments);
            }
        }
    }
}
