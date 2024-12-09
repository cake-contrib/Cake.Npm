namespace Cake.Npm.Publish
{
    using System;
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for publishing npm modules.
    /// </summary>
    public class NpmPublisher : NpmTool<NpmPublishSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmPublisher"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmPublisher(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) 
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Publishes a npm package based on the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Publish(NpmPublishSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            RunCore(settings);
        }
    }
}
