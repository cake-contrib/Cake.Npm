using System;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm.Exec;

/// <summary>
/// Tool for running npm exec.
/// </summary>
/// <param name="fileSystem">The file system.</param>
/// <param name="environment">The environment.</param>
/// <param name="processRunner">The process runner.</param>
/// <param name="tools">The tool locator.</param>
/// <param name="log">Cake log instance.</param>
public class NpmExecRunner(
    IFileSystem fileSystem,
    ICakeEnvironment environment,
    IProcessRunner processRunner,
    IToolLocator tools,
    ICakeLog log) : NpmTool<NpmExecSettings>(fileSystem, environment, processRunner, tools, log)
{
    /// <summary>
    /// Runs npm exec with the specified settings.
    /// </summary>
    /// <param name="settings">The <see cref="NpmExecSettings" />.</param>
    public void Exec(NpmExecSettings settings)
    {
        ArgumentNullException.ThrowIfNull(settings);

        RunCore(settings);
    }
}