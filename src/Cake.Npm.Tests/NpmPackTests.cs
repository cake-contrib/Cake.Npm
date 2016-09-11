using Shouldly;
using Xunit;

namespace Cake.Npm.Tests
{
    public class NpmPackTests
    {
        private readonly NpmPackFixture _fixture;
        public NpmPackTests()
        {
            _fixture = new NpmPackFixture();
        }

        [Fact]
        public void Not_Setting_Target_Should_Use_Empty()
        {
            var result = _fixture.Run();
            result.Args.ShouldBe("pack");
        }

        [Fact]
        public void Including_Target_Should_Set_Correct_Argument()
        {
            _fixture.Target = "package.tgz";
            var result = _fixture.Run();
            result.Args.ShouldBe("pack package.tgz");
        }
    }
}
