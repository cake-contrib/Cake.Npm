namespace Cake.Npm.Ci
{
    using System;
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for installing all npm packages for a project from package-lock.json.
    /// </summary>
    public class NpmCiTool : NpmTool<NpmCiSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmCiTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmCiTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) 
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Installs all npm packages from the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Install(NpmCiSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            RunCore(settings);
        }
    }
}
