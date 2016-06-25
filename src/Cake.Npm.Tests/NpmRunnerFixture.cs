using System;
using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.Npm.Tests {
	public class NpmRunnerFixture : ToolFixture<NpmInstallSettings> {
		public NpmRunnerFixture() : base("npm") { }

		public Action<NpmInstallSettings> InstallSettings { get; set; }

		public DirectoryPath WorkingDirectory { get; set; }

		protected override void RunTool() {
			var tool = new NpmRunner(FileSystem, Environment, ProcessRunner, Tools);
			tool.Install(InstallSettings, WorkingDirectory);
		}
	}

	public class NpmRunScriptFixture : ToolFixture<NpmRunScriptSettings>
	{
		internal string ScriptName { get; set; } = string.Empty;
        internal DirectoryPath WorkingDirectory { get; set; }

		public NpmRunScriptFixture(string scriptName = "build") : base("npm")
		{
			ScriptName = scriptName;
		}
		public Action<NpmRunScriptSettings> RunScriptSettings { get; set; }

		protected override void RunTool()
		{
			var tool = new NpmRunner(FileSystem, Environment, ProcessRunner, Tools);
			tool.RunScript(ScriptName, RunScriptSettings, WorkingDirectory);
		}
	}
}
