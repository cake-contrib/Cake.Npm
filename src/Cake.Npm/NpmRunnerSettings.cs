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

        /// <summary>
        /// The applied log level (if any)
        /// </summary>
        public NpmLogLevel? LogLevel { get; private set; }

        /// <summary>
        /// Specifies the level of logging to use during command execution
        /// </summary>
        /// <param name="logLevel">one of the available log levels</param>
        /// <returns>the settings</returns>
        public NpmRunnerSettings WithLogLevel(NpmLogLevel logLevel)
        {
            LogLevel = logLevel;
            return this;
        }
        
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);
            EvaluateCore(args);
            if (Force) args.Append("--force");
            AppendLogLevel(args);
        }

        private void AppendLogLevel(ProcessArgumentBuilder args)
        {
            if (LogLevel.HasValue)
            {
                switch (LogLevel)
                {
                    case NpmLogLevel.Silent:
                        args.Append("--silent");
                        break;
                    case NpmLogLevel.Warn:
                        args.Append("--warn");
                        break;
                    case NpmLogLevel.Info:
                        args.Append("--loglevel info");
                        break;
                    case NpmLogLevel.Verbose:
                        args.Append("--loglevel verbose");
                        break;
                    case NpmLogLevel.Silly:
                        args.Append("--loglevel silly");
                        break;
                    default:
                        throw new NotImplementedException("Unknown Npm log level");
                }
            }
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