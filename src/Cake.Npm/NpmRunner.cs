using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm
{
    /// <summary>
    /// Npm Runner command interface
    /// </summary>
    public interface INpmRunnerCommands
    {
        /// <summary>
        /// execute 'npm install' with options
        /// </summary>
        /// <param name="configure">options when running 'npm install'</param>
        INpmRunnerCommands Install(Action<NpmInstallSettings> configure = null);

        /// <summary>
        /// execute 'npm run'/'npm run-script' with arguments
        /// </summary>
        /// <param name="scriptName">name of the </param>
        /// <param name="configure"></param>
        INpmRunnerCommands RunScript(string scriptName, Action<NpmRunScriptSettings> configure = null);
    }
    
    /// <summary>
    /// A wrapper around the Node Npm package manager
    /// </summary>
    public class NpmRunner : Tool<NpmRunnerSettings>, INpmRunnerCommands
    {
        private readonly IFileSystem _fileSystem;
        private DirectoryPath _workingDirectoryPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="toolLocator">The tool locator</param>
        /// <param name="workingDirectoryPath"></param>
        internal NpmRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator, DirectoryPath workingDirectoryPath = null) : base(fileSystem, environment, processRunner, toolLocator)
        {
            _fileSystem = fileSystem;
            _workingDirectoryPath = workingDirectoryPath;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public INpmRunnerCommands FromPath(DirectoryPath path)
        {
            _workingDirectoryPath = path;
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

            var args = GetNpmInstallArguments(settings);

            Run(settings, args);
            return this;
        }

        private ProcessArgumentBuilder GetNpmInstallArguments(NpmInstallSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args);
            return args;
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

        private ProcessArgumentBuilder GetNpmRunArguments(NpmRunScriptSettings settings)
        {
            var args = new ProcessArgumentBuilder();
            settings.Evaluate(args);
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
            if(!_fileSystem.Exist(_workingDirectoryPath)) throw new DirectoryNotFoundException($"Working directory path not found [{_workingDirectoryPath.FullPath}]");
            return _workingDirectoryPath;
        }
    }
}
