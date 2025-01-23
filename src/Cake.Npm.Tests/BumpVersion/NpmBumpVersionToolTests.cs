namespace Cake.Npm.Tests.BumpVersion;

using Npm.BumpVersion;

using System;
using System.Collections;
using System.Collections.Generic;

using Xunit;

public class NpmBumpVersionToolTests
{
    public sealed class TheBumpVersionMethod
    {
        private readonly NpmBumpVersionToolFixture fixture;

        public TheBumpVersionMethod()
        {
            fixture = new NpmBumpVersionToolFixture();
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

        [Theory]
        [ClassData(typeof(ExtensionNullCheckData))]
        public void Should_Throw_If_Settings_Are_Null_For_All_Extensions(Action<NpmBumpVersionSettings> extensionAction)
        {
            // Given
            fixture.Settings = null;

            // When
            var result = Record.Exception(() => extensionAction(fixture.Settings));

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
            Assert.Equal("version minor", result.Args);
        }

        [Fact]
        public void Should_Add_Version_Argument()
        {
            // Given
            fixture.Settings.Version = "1.2.3";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version 1.2.3", result.Args);
        }

        [Fact]
        public void Should_Add_Version_Argument_Using_Extensions()
        {
            // Given
            fixture.Settings.WithVersion("1.2.3");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version 1.2.3", result.Args);
        }

        [Fact]
        public void Should_Add_Force_Switch()
        {
            // Given
            fixture.Settings.Force = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version minor -f", result.Args);
        }

        [Fact]
        public void Should_Add_Force_Switch_Using_Extension()
        {
            // Given
            fixture.Settings.WithForce();

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version minor -f", result.Args);
        }

        [Fact]
        public void Should_Add_CommitMessage_Option()
        {
            // Given
            fixture.Settings.CommitMessage = "Bumped minor version.";

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version minor -m \"Bumped minor version.\"", result.Args);
        }

        [Fact]
        public void Should_Add_CommitMessage_Option_Using_Extension()
        {
            // Given
            fixture.Settings.WithCommitMessage("Bumped minor version.");

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version minor -m \"Bumped minor version.\"", result.Args);
        }

        [Fact]
        public void Should_Add_GitTagVersion_True_Switch()
        {
            // Given
            fixture.Settings.WithVersion("11.22.33");
            fixture.Settings.GitTagVersion = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version 11.22.33 --git-tag-version=true", result.Args);
        }

        [Fact]
        public void Should_Add_GitTagVersion_False_Switch()
        {
            // Given
            fixture.Settings.WithVersion("11.22.33");
            fixture.Settings.GitTagVersion = false;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version 11.22.33 --git-tag-version=false", result.Args);
        }

        [Fact]
        public void Should_Add_AllowSameVersion_True_Switch()
        {
            // Given
            fixture.Settings.WithVersion("11.22.33");
            fixture.Settings.AllowSameVersion = true;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version 11.22.33 --allow-same-version=true", result.Args);
        }

        [Fact]
        public void Should_Add_AllowSameVersion_False_Switch()
        {
            // Given
            fixture.Settings.WithVersion("11.22.33");
            fixture.Settings.AllowSameVersion = false;

            // When
            var result = fixture.Run();

            // Then
            Assert.Equal("version 11.22.33 --allow-same-version=false", result.Args);
        }

        class ExtensionNullCheckData : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { (Action<NpmBumpVersionSettings>)(x => x.WithForce()) };
                yield return new object[] { (Action<NpmBumpVersionSettings>)(x => x.WithCommitMessage("")) };
                yield return new object[] { (Action<NpmBumpVersionSettings>)(x => x.WithVersion("")) };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}
