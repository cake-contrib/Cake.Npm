namespace Cake.Npm.Tests.Version
{
    using Cake.Core;
    using Shouldly;
    using Xunit;

    public class NpmVersionToolTests
    {
        public sealed class TheVersionMethod
        {
            [Fact]
            public void Should_Throw_If_Settings_Are_Null()
            {
                // Given
                var fixture = new NpmVersionToolFixture
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
                var fixture = new NpmVersionToolFixture();

                // When
                var result = fixture.Run();

                // Then
                Assert.Equal("version", result.Args);
            }

            [Fact]
            public void Should_Determine_Version_From_StandardOutput()
            {
                string[] versionInfo =
                [
                    "{",
                    "    npm: '5.8.0',",
                    "    ares: '1.10.1-DEV',",
                    "    cldr: '32.0',",
                    "    http_parser: '2.8.0',",
                    "    icu: '60.1',",
                    "    modules: '57',",
                    "    nghttp2: '1.25.0',",
                    "    node: '8.11.1',",
                    "    openssl: '1.0.2o',",
                    "    tz: '2017c',",
                    "    unicode: '10.0',",
                    "    uv: '1.19.1',",
                    "    v8: '6.2.414.50',",
                    "    zlib: '1.2.11'",
                    "}",
"",
"",
                    "╭─────────────────────────────────────╮",
                    "│ │",
                    "│ Update available 5.6.0 → 6.1.0 │",
                    "│ Run npm i -g npm to update │",
                    "│ │",
                    "╰─────────────────────────────────────╯"
                ];

                // Given
                var fixture = new NpmVersionToolFixture();
                fixture.ProcessRunner.Process.SetStandardOutput(versionInfo);

                // When
                _ = fixture.Run();

                // Then
                fixture.Version.ShouldBe("5.8.0");
            }

            [Theory]
            [InlineData("{npm: '1.0.0'}", "1.0.0")]
            [InlineData("{ npm: '1.0.0',\r\n{stuff: '0.0.1' }", "1.0.0")]
            [InlineData("", "")]
            [InlineData(null, "")]
            [InlineData("not valid", "")]
            public void Should_Determine_Version_From_StandardOutput_Scenarios(string standardOutput, string expectedVersion)
            {
                string[] output = standardOutput.SplitLines();

                // Given
                var fixture = new NpmVersionToolFixture();
                fixture.ProcessRunner.Process.SetStandardOutput(output);

                // When
                _ = fixture.Run();

                // Then
                fixture.Version.ShouldBe(expectedVersion);
            }
        }
    }
}
