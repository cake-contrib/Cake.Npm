namespace Cake.Npm.View
{
    using Cake.Core;
    using Cake.Core.Diagnostics;
    using Cake.Core.IO;
    using Cake.Core.Tooling;
    using System.Collections.Generic;

    /// <summary>
    /// Tool for viewing registry info.
    /// </summary>
    public class NpmViewTool : NpmTool<NpmSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmViewTool"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tool locator.</param>
        /// <param name="log">Cake log instance.</param>
        public NpmViewTool(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log)
            : base(fileSystem, environment, processRunner, tools, log)
        {
        }

        /// <summary>
        /// Returns information about a package registry entry.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public string View(NpmViewSettings settings)
        {
            try
            {
                IEnumerable<string> output = new List<string>();
                RunCore(
                    settings,
                    new ProcessSettings(),
                    process =>
                    {
                        output = process.GetStandardOutput();
                    });
                return string.Join("\n", output);

            }
            catch (CakeException)
            {
                CakeLog.Information("Error should be a 404 and i ignore it.");
                return "";
            }
        }
    }
}
