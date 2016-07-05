using System;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Testing.Fixtures;

namespace Cake.Npm.Tests {
	public class NpmRunnerFixture : ToolFixture<NpmInstallSettings> {
	    private Verbosity _level = Verbosity.Normal;
	    private NpmLogLevel? _npmLogLevel;

	    public NpmRunnerFixture() : base("npm") { }

		public Action<NpmInstallSettings> InstallSettings { get; set; }

        public NpmRunnerFixture WithLogLevel(NpmLogLevel npmLogLevel)
        {
            _npmLogLevel = npmLogLevel;
            return this;
        }

        public NpmRunnerFixture WithVerbosity(Verbosity level)
	    {
	        _level = level;
	        return this;
	    }

		protected override void RunTool() {
			var tool = new NpmRunner(FileSystem, Environment, ProcessRunner, Tools, _level);
		    if(_npmLogLevel.HasValue) tool.WithLogLevel(_npmLogLevel.Value);
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
