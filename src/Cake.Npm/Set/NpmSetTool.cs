namespace Cake.Npm.Set;

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
public class NpmSetTool(
    IFileSystem fileSystem,
    ICakeEnvironment environment,
    IProcessRunner processRunner,
    IToolLocator tools,
    ICakeLog log) : NpmTool<NpmSetSettings>(fileSystem, environment, processRunner, tools, log)
{

    /// <summary>
    /// Sets a configuration key/value
    /// </summary>
    /// <param name="settings">The settings</param>
    public void Set(NpmSetSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        RunCore(settings);
    }
}
