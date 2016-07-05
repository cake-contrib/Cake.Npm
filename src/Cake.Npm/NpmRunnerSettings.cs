using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm
{
    /// <summary>
    /// Npm runner settings
    /// </summary>
    public abstract class NpmRunnerSettings : ToolSettings
    {
        /// <summary>
        /// The command being ran
        /// </summary>
        protected string Command { get; set; }

        /// <summary>
        /// Creates Npm Runner settings
        /// </summary>
        /// <param name="command">command to run</param>
        protected NpmRunnerSettings(string command)
        {
            Command = command;
        }

        /// <summary>
        /// Applies the --force parameter
        /// </summary>
        public bool Force { get; private set; }

        /// <summary>
        /// Whether to set --force
        /// </summary>
        /// <param name="enabled">should use --force</param>
        /// <returns>the settings</returns>
        public NpmRunnerSettings WithForce(bool enabled = true)
        {
            Force = enabled;
            return this;
        }

        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);
            EvaluateCore(args);
            if (Force) args.Append("--force");
        }

        /// <summary>
        /// evaluate options
        /// </summary>
        /// <param name="args"></param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
        }
    }
}