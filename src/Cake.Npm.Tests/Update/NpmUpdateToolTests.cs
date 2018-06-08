using Cake.Npm.Update;
using Xunit;

namespace Cake.Npm.Tests.Update
{
    public class NpmUpdateToolTests
    {
        public sealed class TheAutomatedInstallMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new NpmUpdateToolFixture();
                fixture.Settings.RedirectStandardError = true;

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmUpdateToolFixture();
                fixture.Settings = null;

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }

            [Fact]
            public void Should_Add_Mandatory_Arguments()
            {
                // Given
                var fixture = new NpmUpdateToolFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("update", result.Args);
            }

            [Fact]
            public void Should_Include_Global_Flag()
            {
                // Given
                var fixture = new NpmUpdateToolFixture();
                fixture.Settings.UpdateGlobalPackages();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("update -g", result.Args);
            }

        }
    }
}
