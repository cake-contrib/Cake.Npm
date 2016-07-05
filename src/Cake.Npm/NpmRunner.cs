using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm
{
    /// <summary>
    /// Npm Runner configuration
    /// </summary>
    public interface INpmRunnerConfiguration
    {
        /// <summary>
        /// Sets the working directory for npm commands
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        INpmRunnerCommands FromPath(DirectoryPath path);
 
        /// <summary>
        /// Sets the npm logging level
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        INpmRunnerConfiguration WithLogLevel(NpmLogLevel logLevel);
    }

    /// <summary>
    /// A wrapper around the Node Npm package manager
    /// </summary>
    public class NpmRunner : Tool<NpmRunnerSettings>, INpmRunnerCommands, INpmRunnerConfiguration
    {
        private readonly IFileSystem _fileSystem;
        private readonly Verbosity _cakeVerbosityLevel;
        private DirectoryPath _workingDirectoryPath;
        private NpmLogLevel? _logLevel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="toolLocator">The tool locator</param>
        /// <param name="cakeVerbosityLevel">Specifies the current Cake verbosity level</param>
        internal NpmRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator, Verbosity cakeVerbosityLevel = Verbosity.Normal) : base(fileSystem, environment, processRunner, toolLocator)
        {
            _fileSystem = fileSystem;
            _cakeVerbosityLevel = cakeVerbosityLevel;
        }

        /// <summary>
        /// Sets the working directory for npm commands
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public INpmRunnerCommands FromPath(DirectoryPath path)
        {
            _workingDirectoryPath = path;
            return this;
        }


        /// <summary>
        /// Sets the npm logging level
        /// </summary>
        /// <param name="logLevel"></param>
        /// <returns></returns>
        public INpmRunnerConfiguration WithLogLevel(NpmLogLevel logLevel)
        {
            _logLevel = logLevel;
            return this;
        }

        /// <summary>
        /// execute 'npm install' with options
        /// </summary>
        /// <param name="configure">options when running 'npm install'</param>
        public INpmRunnerCommands Install(Action<NpmInstallSettings> configure = null)
        {
            var settings = new NpmInstallSettings();
            configure?.Invoke(settings);

            var args = GetNpmInstallArguments(settings, _cakeVerbosityLevel, _logLevel);

            Run(settings, args);
            return this;
        }

        private static ProcessArgumentBuilder GetNpmInstallArguments(NpmInstallSettings settings, Verbosity cakeVerbosityLevel, NpmLogLevel? logLevel)
        {
            var args = new ProcessArgumentBuilder();
            if (!logLevel.HasValue)
            {
                logLevel = CakeToNpmLogLevelConverter(cakeVerbosityLevel);
            }
            settings.Evaluate(args);
            AppendLogLevel(args, logLevel);
            return args;
        }

        private static void AppendLogLevel(ProcessArgumentBuilder args, NpmLogLevel? logLevel)
        {
            if (logLevel.HasValue)
            {
                switch (logLevel)
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
                }
            }
        }


        private static NpmLogLevel? CakeToNpmLogLevelConverter(Verbosity cakeVerbosityLevel)
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
                    return null;
            }
        }

        /// <summary>
        /// execute 'npm run'/'npm run-script' with arguments
        /// </summary>
        /// <param name="scriptName">name of the </param>
        /// <param name="configure"></param>
        public INpmRunnerCommands RunScript(string scriptName, Action<NpmRunScriptSettings> configure = null)
        {
            var settings = new NpmRunScriptSettings(scriptName);
            configure?.Invoke(settings);
            var args = GetNpmRunArguments(settings);

            Run(settings, args);
            return this;
        }

        private static ProcessArgumentBuilder GetNpmRunArguments(NpmRunScriptSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings?.Evaluate(args);
            return args;
        }

        /// <summary>
        /// Gets the name of the tool
        /// </summary>
        /// <returns>the name of the tool</returns>
        protected override string GetToolName()
        {
            return "Npm Runner";
        }

        /// <summary>
        /// Gets the name of the tool executable
        /// </summary>
        /// <returns>The tool executable name</returns>
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "npm.cmd";
            yield return "npm";
        }

        /// <summary>
        /// Gets the working directory from the NpmRunnerSettings
        ///             Defaults to the currently set working directory.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// The working directory for the tool.
        /// </returns>
        protected override DirectoryPath GetWorkingDirectory(NpmRunnerSettings settings)
        {
            if (_workingDirectoryPath == null) return base.GetWorkingDirectory(settings);
            if (!_fileSystem.Exist(_workingDirectoryPath)) throw new DirectoryNotFoundException($"Working directory path not found [{_workingDirectoryPath.FullPath}]");
            return _workingDirectoryPath;
        }
    }
}
