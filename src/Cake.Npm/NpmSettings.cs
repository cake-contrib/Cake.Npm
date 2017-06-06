using System.Collections.Generic;
using System.Linq;

namespace Cake.Npm
{
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Npm tool settings.
    /// </summary>
    public abstract class NpmSettings: ToolSettings
    {
        private readonly List<string> _npmArguments = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmSettings"/> class.
        /// </summary>
        /// <param name="command">Command to run.</param>
        protected NpmSettings(string command)
        {
            Command = command;
        }

        /// <summary>
        /// Gets or sets the log level which should be used to run the npm command.
        /// </summary>
        public NpmLogLevel LogLevel { get; set; }

        /// <summary>
        /// Gets or sets the Log level set by Cake.
        /// </summary>
        internal Verbosity? CakeVerbosityLevel { get; set; }

        /// <summary>
        /// Arguments to pass to npm.
        /// </summary>
        public IList<string> NpmArguments
        {
            get
            {
                return _npmArguments;
            }
        }

        /// <summary>
        /// Gets the command which should be run.
        /// </summary>
        protected string Command { get; private set; }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        internal void Evaluate(ProcessArgumentBuilder args)
        {
            args.Append(Command);
            AppendNpmSettings(args);
            EvaluateCore(args);
        }

        /// <summary>
        /// Evaluates the settings and appends Npm specific options to arguments
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        private void AppendNpmSettings(ProcessArgumentBuilder args)
        {
            AppendLogLevel(args, LogLevel);
            foreach (var arg in NpmArguments)
            {
                args.Append(arg);
            }
        }

        /// <summary>
        /// Evaluates the settings and writes them to <paramref name="args"/>.
        /// </summary>
        /// <param name="args">The argument builder into which the settings should be written.</param>
        protected virtual void EvaluateCore(ProcessArgumentBuilder args)
        {
        }

        private void AppendLogLevel(ProcessArgumentBuilder args, NpmLogLevel logLevel)
        {
            if (logLevel == NpmLogLevel.Default && CakeVerbosityLevel.HasValue)
            {
                logLevel = CakeToNpmLogLevelConverter(CakeVerbosityLevel.Value);
            }

            switch (logLevel)
            {
                case NpmLogLevel.Default:
                    break;
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
                case NpmLogLevel.Error:
                    args.Append("--loglevel error");
                    break;
                case NpmLogLevel.Http:
                    args.Append("--loglevel http");
                    break;
            }
        }

        private static NpmLogLevel CakeToNpmLogLevelConverter(Verbosity cakeVerbosityLevel)
        {
            switch (cakeVerbosityLevel)
            {
                case Verbosity.Quiet:
                    return NpmLogLevel.Silent;
                case Verbosity.Minimal:
                    return NpmLogLevel.Warn;
                case Verbosity.Verbose:
                    return NpmLogLevel.Info;
                case Verbosity.Diagnostic:
                    return NpmLogLevel.Verbose;
                default:
                    return NpmLogLevel.Default;
            }
        }
    }
}
