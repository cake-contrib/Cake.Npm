namespace Cake.Npm.Pack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Diagnostics;
    using Core.IO;
    using Core.Tooling;

    /// <summary>
    /// Tool for packaging npm modules.
    /// </summary>
    public class NpmPacker : NpmTool<NpmPackSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmPacker"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmPacker(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log) 
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Creates a npm package from the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>List of created packages.</returns>
        public IEnumerable<FilePath> Pack(NpmPackSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var processSettings = new ProcessSettings
            {
                Arguments = GetArguments(settings),
                RedirectStandardOutput = true
            };

            var packages = new List<FilePath>();
            RunCore(
                settings,
                processSettings,
                process => {
                    var output = process.GetStandardOutput();
                    if (output != null)
                    {
                        packages.AddRange(
                            output.Select(x => GetWorkingDirectory(settings).GetFilePath(new FilePath(x))));
                    }
                });

            return packages;
        }
    }
}
