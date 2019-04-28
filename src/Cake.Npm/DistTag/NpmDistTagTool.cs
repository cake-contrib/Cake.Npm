namespace Cake.Npm.DistTag
{
    using System;
    using Cake.Core;
    using Cake.Core.Diagnostics;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// Tool for running npm dist-tags.
    /// </summary>
    public class NpmDistTagTool : NpmTool<BaseNpmDistTagSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmDistTagTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmDistTagTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log)
           : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Runs <c>npm dist-tags</c> with the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void RunDistTag(BaseNpmDistTagSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            RunCore(settings);
        }
    }
}
