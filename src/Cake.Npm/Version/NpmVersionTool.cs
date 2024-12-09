namespace Cake.Npm.Version
{
    using System.Linq;
    using System.Text.RegularExpressions;
    using System;
    using Cake.Core;
    using Cake.Core.Diagnostics;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    /// <summary>
    /// Tool for installing all npm packages for a project from package-lock.json.
    /// </summary>
    /// <param name="fileSystem">The file system.</param>
    /// <param name="environment">The environment.</param>
    /// <param name="processRunner">The process runner.</param>
    /// <param name="tools">The tool locator.</param>
    /// <param name="log">Cake log instance.</param>
    public partial class NpmVersionTool(
        IFileSystem fileSystem,
        ICakeEnvironment environment,
        IProcessRunner processRunner,
        IToolLocator tools,
        ICakeLog log) : NpmTool<NpmVersionSettings>(fileSystem, environment, processRunner, tools, log)
    {

        /// <summary>
        /// Installs all npm packages from the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public string Version(NpmVersionSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            var versionString = string.Empty;

            RunCore(settings, new ProcessSettings(), process =>
            {
                var processOutput = process.GetStandardOutput();
                if (processOutput?.Any() ?? false)
                {
                    var output = string.Join(Environment.NewLine, processOutput);
                    var match = VersionRegex().Match(output);
                    if (match.Success)
                    {
                        versionString = match.Groups["version"].Value;
                    }
                }
            });

            return versionString;
        }

        [GeneratedRegex("(?<component>npm): '(?<version>.*)'")]
        private static partial Regex VersionRegex();
    }
}
