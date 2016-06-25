using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm
{
	/// <summary>
	/// npm run-script options
	/// </summary>
	public class NpmRunScriptSettings : NpmRunnerSettings
	{
		/// <summary>
		/// Arguments to pass to the target script
		/// </summary>
		public IList<string> Arguments { get; set; } = new List<string>();

        /// <summary>
        /// npm 'run-script' settings
        /// </summary>
        public NpmRunScriptSettings() : base("run-script")
        {

        }

        /// <summary>
        /// npm 'run-script' settings
        /// </summary>
        public NpmRunScriptSettings(DirectoryPath workingDirectoryPath = null) : base("run-script", workingDirectoryPath)
		{
			
		}

	    /// <summary>
	    /// npm 'run-script' settings for the named script
	    /// </summary>
	    /// <param name="command">script name to execute</param>
	    /// <param name="workingDirectoryPath"></param>
	    public NpmRunScriptSettings(string command, DirectoryPath workingDirectoryPath = null) : base("run-script", workingDirectoryPath)
		{
			ScriptName = command;
		}

		/// <summary>
		/// Name of the script to execute as defined in package.json
		/// </summary>
		public string ScriptName { get; set; } = string.Empty;

		/// <summary>
		/// evaluate options
		/// </summary>
		/// <param name="args"></param>
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

		/// <summary>
		/// adds
		/// </summary>
		/// <param name="arg"></param>
		/// <returns></returns>
		public NpmRunScriptSettings WithArgument(string arg)
		{
			Arguments.Add(arg);
			return this;
		}

		/// <summary>
		/// Unsupported
		/// </summary>
		/// <param name="force"></param>
		protected new void WithForce(bool force)
		{
			
		}
	}
}
