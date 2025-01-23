namespace Cake.Npm;

using System;
using System.Collections.Generic;
using Core;
using Core.Diagnostics;
using Core.IO;
using Core.Tooling;

/// <summary>
/// Base class for all npm tools.
/// </summary>
/// <typeparam name="TSettings">The settings type.</typeparam>
/// <param name="fileSystem">The file system.</param>
/// <param name="environment">The environment.</param>
/// <param name="processRunner">The process runner.</param>
/// <param name="tools">The tool locator.</param>
/// <param name="log">Cake log instance.</param>
public abstract class NpmTool<TSettings>(
    IFileSystem fileSystem,
    ICakeEnvironment environment,
    IProcessRunner processRunner,
    IToolLocator tools,
    ICakeLog log) : Tool<TSettings>(fileSystem, environment, processRunner, tools)
    where TSettings : NpmSettings
{
    private readonly ICakeLog _log = log;

    /// <summary>
    /// Cake log instance.
    /// </summary>
    public ICakeLog CakeLog
    {
        get
        {
            return _log;
        }
    }

    /// <summary>
    /// Gets the name of the tool.
    /// </summary>
    /// <returns>The name of the tool.</returns>
    protected sealed override string GetToolName()
    {
        return "Npm";
    }

    /// <summary>
    /// Gets the possible names of the tool executable.
    /// </summary>
    /// <returns>The tool executable name.</returns>
    protected sealed override IEnumerable<string> GetToolExecutableNames()
    {
        return ["npm.cmd", "npm"];
    }

    /// <summary>
    /// Runs npm.
    /// </summary>
    /// <param name="settings">The settings.</param>
    protected void RunCore(TSettings settings)
    {
        RunCore(settings, new ProcessSettings(), null);
    }

    /// <summary>
    /// Runs npm.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="processSettings">The process settings. <c>null</c> for default settings.</param>
    /// <param name="postAction">Action which should be executed after running npm. <c>null</c> for no action.</param>
    protected void RunCore(TSettings settings, ProcessSettings processSettings, Action<IProcess> postAction)
    {
        ArgumentNullException.ThrowIfNull(settings);

        if (!settings.CakeVerbosityLevel.HasValue)
        {
            settings.CakeVerbosityLevel = CakeLog.Verbosity;
        }

        processSettings.RedirectStandardOutput =
            settings.RedirectStandardOutput ||
            settings.StandardOutputAction != null;

        if (settings.StandardOutputAction != null)
        {
            processSettings.RedirectedStandardOutputHandler = x =>
            {
                settings.StandardOutputAction(x);
                return x;
            };
        }

        processSettings.RedirectStandardError =
            settings.RedirectStandardError ||
            settings.StandardErrorAction != null;

        if (settings.StandardErrorAction != null)
        {
            processSettings.RedirectedStandardErrorHandler = x =>
            {
                settings.StandardErrorAction(x);
                return x;
            };
        }

        var args = GetArguments(settings);
        Run(settings, args, processSettings, postAction);
    }

    /// <summary>
    /// Builds the arguments for npm.
    /// </summary>
    /// <param name="settings">Settings used for building the arguments.</param>
    /// <returns>Argument builder containing the arguments based on <paramref name="settings"/>.</returns>
    protected ProcessArgumentBuilder GetArguments(TSettings settings)
    {
        var args = new ProcessArgumentBuilder();
        settings.Evaluate(args);

        CakeLog.Verbose("npm arguments: {0}", args.RenderSafe());

        return args;
    }
}
