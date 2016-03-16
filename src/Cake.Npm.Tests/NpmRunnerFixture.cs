using System;

using Cake.Testing.Fixtures;

namespace Cake.Npm.Tests {
	public class NpmRunnerFixture : ToolFixture<NpmInstallSettings> {
		public NpmRunnerFixture() : base("npm") { }

		public Action<NpmInstallSettings> InstallSettings { get; set; }

		protected override void RunTool() {
			var tool = new NpmRunner(FileSystem, Environment, ProcessRunner, Globber);
			tool.Install(InstallSettings);
		}
	}
}