namespace Cake.Npm.RunScript
{
    using System;
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for running npm scripts.
    /// </summary>
    public class NpmScriptRunner : NpmTool<NpmRunScriptSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmScriptRunner"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmScriptRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) 
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Runs a npm script with the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void RunScript(NpmRunScriptSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunCore(settings);
        }
    }
}
