using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmRunner" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system</param>
        /// <param name="environment">The environment</param>
        /// <param name="processRunner">The process runner</param>
        /// <param name="globber">The globber</param>
        internal NpmRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
        }
        
        /// <summary>
        /// execute 'npm install' with options
        /// </summary>
        /// <param name="configure">options when running 'npm install'</param>
        public void Install(Action<NpmInstallSettings> configure = null)
        {
            var settings = new NpmInstallSettings();
            configure?.Invoke(settings);

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
    }
}
