using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm
{
	public class NpmRunScriptSettings : NpmRunnerSettings
	{
		public IList<string> Arguments { get; set; } = new List<string>();

		public NpmRunScriptSettings() : base("run")
		{
			
		}
		public NpmRunScriptSettings(string command) : base("run")
		{
			ScriptName = command;
		}

		protected string ScriptName { get; set; } = String.Empty;

		protected override void EvaluateCore(ProcessArgumentBuilder args)
		{
			if (Force) throw new NotImplementedException("npm run-script does not support --force flag");
			if (string.IsNullOrEmpty(ScriptName)) throw new ArgumentNullException(nameof(ScriptName), "Must provide script name!");
			args.Append(ScriptName);
			if (Arguments.Any())
			{
				args.Append("--");
				foreach (var arg in Arguments)
				{
					args.Append(arg);
				}
			}
			base.EvaluateCore(args);
		}

		public NpmRunScriptSettings WithArgument(string arg)
		{
			Arguments.Add(arg);
			return this;
		}

		protected virtual void WithForce(bool force)
		{
			
		}
	}
}
