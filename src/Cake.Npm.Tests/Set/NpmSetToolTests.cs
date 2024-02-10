using Cake.Npm.Set;
using Shouldly;
using Xunit;

namespace Cake.Npm.Tests.Set
{
    public class NpmSetToolTests
    {
        public sealed class TheSetMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new NpmSetToolFixture();
                fixture.Settings.RedirectStandardError = true;
                fixture.Settings.Key = "progress";
                fixture.Settings.Value = "false";
                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmSetToolFixture
                {
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new NpmSetToolFixture();
                fixture.Settings.Key = "progress";
                fixture.Settings.Value = "false";

                // When
                var result = fixture.Run();

                // Then
                result.Args.ShouldStartWith("set");
            }

            [Theory]
            [InlineData("progress", "false", false, "\"progress\"=\"false\"")]
            [InlineData("progress", "false", true, "\"progress\"=\"false\" -g")]
            [InlineData("progress state", "hello world", true, "\"progress state\"=\"hello world\" -g")]
            public void Should_Create_Set_Command_Arguments(string key, string value, bool global, string expected)
            {
                // Given
                var fixture = new NpmSetToolFixture();
                fixture.Settings.Key = key;
                fixture.Settings.Value = value;
                fixture.Settings.Global = global;

                // When
                var result = fixture.Run();

                // Then
                result.Args.ShouldEndWith(expected);
            }

        }
    }
}
