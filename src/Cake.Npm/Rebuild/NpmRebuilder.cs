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
    public class NpmRebuilder : NpmTool<NpmRebuildSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmRebuilder"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmRebuilder(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log)
            : base (fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Rebuilds a npm package from the specified settings.
        /// </summary>
        /// <param name="settings"></param>
        public void Rebuild(NpmRebuildSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunCore(settings);
        }
    }
}