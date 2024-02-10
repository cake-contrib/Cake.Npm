using System;
using Xunit;
using Cake.Npm.AddUser;

namespace Cake.Npm.Tests.AddUser
{
    public class NpmAddUserTests
    {
        public sealed class TheAddUserMethod
        {
            [Fact]
            public void Should_Redirect_Standard_Error()
            {
                var fixture = new NpmAddUserFixture();
                fixture.Settings.RedirectStandardError = true;

                var result = fixture.Run();

                Assert.True(result.Process.RedirectStandardError);
            }

            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmAddUserFixture
                {
                    Settings = null
                };

                // When
                var result = Record.Exception(() => fixture.Run());

                // Then
                result.IsArgumentNullException("settings");
            }
            
            [Fact]
            public void Should_Add_Registry_Url_To_Arguments()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.ForRegistry(new Uri("https://registry.com"));

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser --registry https://registry.com/", result.Args);
            }
            
            [Fact]
            public void Should_Add_Scope_To_Arguments()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.ForScope("@foo");

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser --scope @foo", result.Args);
            }
            
            [Fact]
            public void Should_Throw_If_Scope_Does_Not_Start_With_At()
            {
                // Given
                var fixture = new NpmAddUserFixture();

                // When
                var result = Record.Exception(() => fixture.Settings.ForScope("bar"));

                // Then
                Assert.IsType<ArgumentException>(result);
            }

            [Fact]
            public void Should_Add_AlwaysAuth_To_Arguments_If_True()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.AlwaysAuth = true;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser --always-auth", result.Args);
            }
            
            [Fact]
            public void Should_Not_Add_Registry_To_Arguments_If_Not_Set()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.Registry = null;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser", result.Args);
            }

            [Fact]
            public void Should_Add_AuthType_Of_Legacy()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.AuthType = AuthType.Legacy;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser --auth-type legacy", result.Args);
            }

            [Fact]
            public void Should_Add_AuthType_Of_OAuth()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.AuthType = AuthType.OAuth;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser --auth-type oauth", result.Args);
            }

            [Fact]
            public void Should_Add_AuthType_Of_SSO()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.AuthType = AuthType.SSO;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser --auth-type sso", result.Args);
            }

            [Fact]
            public void Should_Add_AuthType_Of_Saml()
            {
                // Given
                var fixture = new NpmAddUserFixture();
                fixture.Settings.AuthType = AuthType.Saml;

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("adduser --auth-type saml", result.Args);
            }
        }
    }
}
