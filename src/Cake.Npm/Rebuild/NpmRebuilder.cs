namespace Cake.Npm.Rebuild
{
    using System;
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for rebuilding npm modules.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public class NpmRebuilder(
        IFileSystem fileSystem,
        ICakeEnvironment environment,
        IProcessRunner processRunner,
        IToolLocator tools,
        ICakeLog log) : NpmTool<NpmRebuildSettings>(fileSystem, environment, processRunner, tools, log)
    {

        /// <summary>
        /// Rebuilds a npm package from the specified settings.
        /// </summary>
        /// <param name="settings"></param>
        public void Rebuild(NpmRebuildSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            RunCore(settings);
        }
    }
}