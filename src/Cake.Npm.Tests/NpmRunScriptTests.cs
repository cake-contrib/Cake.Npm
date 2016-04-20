using System;
using Shouldly;
using Cake.Testing.Fixtures;
using Xunit;

namespace Cake.Npm.Tests
{
	public class NpmRunScriptTests
	{
		private readonly NpmRunScriptFixture _fixture;
		public NpmRunScriptTests()
		{
			_fixture = new NpmRunScriptFixture();
		}

		[Fact]
		public void Not_Setting_ScriptName_Should_Fail()
		{
			_fixture.ScriptName = "";
			Assert.Throws<ArgumentNullException>(() => _fixture.Run());
		}

		[Fact]
		public void Setting_Force_Should_Throw_Exception()
		{
			_fixture.RunScriptSettings = s => s.WithForce();
			Assert.Throws<NotImplementedException>(() => _fixture.Run());
		}

		[Fact]
		public void Not_Including_Args_Should_Produce_Empty_Command()
		{
			var result = _fixture.Run();
			result.Args.ShouldBe("run script");
		}

		[Fact]
		public void Including_Args_Should_Add_Delimiter()
		{
			_fixture.RunScriptSettings = s => s.WithArgument("-param");

			var result = _fixture.Run();
			result.Args.ShouldBe("run script -- -param");
		}

		[Fact]
		public void Including_Multiple_Args_Should_Include_All()
		{
			_fixture.RunScriptSettings = s => s.WithArgument("-param").WithArgument("-default");
			var result = _fixture.Run();
			result.Args.ShouldBe("run script -- -param -default");
		}

		[Fact]
		public void Run_Named_Script_Should_Run_Correct_Script()
		{
			_fixture.ScriptName = "build";
			var result = _fixture.Run();
			result.Args.ShouldBe("run build");
		}

		[Fact]
		public void Named_Script_Should_Insert_Args_Correctly()
		{
			_fixture.ScriptName = "build";
			_fixture.RunScriptSettings = s => s.WithArgument("-param").WithArgument("-default");
			var result = _fixture.Run();
			result.Args.ShouldBe("run build -- -param -default");
		}
	}
}
