using System;

using Cake.Testing.Fixtures;

namespace Cake.Npm.Tests {
	public class NpmRunnerFixture : ToolFixture<NpmInstallSettings> {
		public NpmRunnerFixture() : base("npm") { }

		public Action<NpmInstallSettings> InstallSettings { get; set; }

		

		protected override void RunTool() {
			var tool = new NpmRunner(FileSystem, Environment, ProcessRunner, Tools);
			tool.Install(InstallSettings);
		}
	}

	public class NpmRunScriptFixture : ToolFixture<NpmRunScriptSettings>
	{
		internal string ScriptName { get; set; } = string.Empty;

		public NpmRunScriptFixture(string scriptName = "build") : base("npm")
		{
			ScriptName = scriptName;
		}
		public Action<NpmRunScriptSettings> RunScriptSettings { get; set; }

		protected override void RunTool()
		{
			var tool = new NpmRunner(FileSystem, Environment, ProcessRunner, Tools);
			tool.RunScript(ScriptName, RunScriptSettings);
		}
	}
}
