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
        /// <param name="workingDirectoryPath"></param>
        protected NpmRunnerSettings(string command, DirectoryPath workingDirectoryPath = null)
        {
            Command = command;
            WorkingDirectory = workingDirectoryPath;
        }

        /// <summary>
        /// Applies the --force parameter
        /// </summary>
        public bool Force { get; private set; }

        /// <summary>
        /// Whether to set --force
        /// </summary>
        /// <param name="enabled">should use --force</param>
        public void WithForce(bool enabled = true)
        {
            Force = enabled;
        }

        /// <summary>
        /// A custom working directory to use when executing npm
        /// </summary>
        public DirectoryPath WorkingDirectory { get; private set; }

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