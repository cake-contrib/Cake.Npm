namespace Cake.Npm.Update
{
    using System;
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for installing all npm packages for a project from package-lock.json.
    /// </summary>
    public class NpmUpdateTool : NpmTool<NpmUpdateSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmUpdateTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmUpdateTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) 
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Updates all npm packages.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Update(NpmUpdateSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunCore(settings);
        }
    }
}
