using System;
using System.Collections.Generic;
using System.IO;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm
{
    /// <summary>
    /// A wrapper around the Node Npm package manager
    /// </summary>
    public class NpmRunner : Tool<NpmRunnerSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="NpmRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="toolLocator">The tool locator</param>
        internal NpmRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator toolLocator) : base(fileSystem, environment, processRunner, toolLocator)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// execute 'npm install' with options
        /// </summary>
        /// <param name="configure">options when running 'npm install'</param>
        /// <param name="workingDirectoryPath">The working directory path</param>
        public void Install(Action<NpmInstallSettings> configure = null, DirectoryPath workingDirectoryPath = null)
        {
            var settings = new NpmInstallSettings(workingDirectoryPath);
            configure?.Invoke(settings);

            var args = GetNpmInstallArguments(settings);

            Run(settings, args);
        }

        /// <summary>
        /// sets the working directory and executes 'npm install' within it
        /// </summary>
        /// <param name="workingDirectoryPath">The working directory path</param>
        public void Install(DirectoryPath workingDirectoryPath = null)
        {
            var settings = new NpmInstallSettings(workingDirectoryPath);

            var args = GetNpmInstallArguments(settings);

            Run(settings, args);
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
        /// <param name="workingDirectoryPath">The working directory path</param>
        public void RunScript(string scriptName, Action<NpmRunScriptSettings> configure = null, DirectoryPath workingDirectoryPath = null)
        {
            var settings = new NpmRunScriptSettings(scriptName, workingDirectoryPath);
            configure?.Invoke(settings);
            var args = GetNpmRunArguments(settings);

            Run(settings, args);
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
            if (settings.WorkingDirectory == null) return base.GetWorkingDirectory(settings);
            if(!_fileSystem.Exist(settings.WorkingDirectory)) throw new DirectoryNotFoundException($"Working directory path not found [{settings.WorkingDirectory}]");
            return settings.WorkingDirectory;
        }
    }
}
