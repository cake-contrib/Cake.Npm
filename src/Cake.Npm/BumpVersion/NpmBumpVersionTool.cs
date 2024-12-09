namespace Cake.Npm.BumpVersion
{
    using System;

    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for bumping the version.
    /// </summary>
    public class NpmBumpVersionTool : NpmTool<NpmBumpVersionSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmBumpVersionTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmBumpVersionTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) 
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Calls npm version to bump a version.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void BumpVersion(NpmBumpVersionSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            RunCore(settings);
        }
    }
}
