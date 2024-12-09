namespace Cake.Npm.ViewVersion
{
    using System;
    using System.Linq;

    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for viewing npm package versions.
    /// </summary>
    public class NpmViewVersionTool : NpmTool<NpmViewVersionSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmViewVersionTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmViewVersionTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) 
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Views the package version from the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public string Version(NpmViewVersionSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            var versionString = string.Empty;

            RunCore(settings, new ProcessSettings(), process =>
            {
                var processOutput = process.GetStandardOutput()?.ToList();
                if (processOutput?.Any() ?? false)
                {
                    versionString = processOutput.First();
                }
            });

            return versionString;
        }
    }
}
