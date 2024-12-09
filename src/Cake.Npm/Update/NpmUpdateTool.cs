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
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public class NpmUpdateTool(
        IFileSystem fileSystem,
        ICakeEnvironment environment,
        IProcessRunner processRunner,
        IToolLocator tools,
        ICakeLog log) : NpmTool<NpmUpdateSettings>(fileSystem, environment, processRunner, tools, log)
    {

        /// <summary>
        /// Updates all npm packages.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Update(NpmUpdateSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            RunCore(settings);
        }
    }
}
