namespace Cake.Npm;

using System;

using Core;
using Core.Diagnostics;
using Core.IO;
using Core.Tooling;

/// <summary>
/// Npm tool settings.
/// </summary>
/// <param name="command">Command to run.</param>
public abstract class NpmSettings(string command) : ToolSettings
{

    /// <summary>
    /// Gets or sets the log level which should be used to run the npm command.
    /// </summary>
    public NpmLogLevel LogLevel { get; set; }

    /// <summary>
    /// Gets or sets the process option to redirect standard error output.
    /// </summary>
    /// <remarks>
    /// To retrieve and process the standard error output 
    /// <see cref="StandardErrorAction"/> needs to be set.
    /// </remarks>
    public bool RedirectStandardError { get; set; } = false;

    /// <summary>
    /// Gets or sets an action to retrieve and process standard error output.
    /// </summary>
    /// <remarks>
    /// Setting a standard error action implicitely set <see cref="RedirectStandardError"/>.
    /// </remarks>
    public Action<string> StandardErrorAction { get; set; }

    /// <summary>
    /// Gets or sets the process option to redirect standard output.
    /// </summary>
    /// <remarks>
    /// To retrieve and process the standard error output 
    /// <see cref="StandardOutputAction"/> needs to be set.
    /// </remarks>
    public bool RedirectStandardOutput { get; set; } = false;

    /// <summary>
    /// Gets or sets an action to retrieve and process standard output.
    /// </summary>
    /// <remarks>
    /// Setting a standard error action implicitely set <see cref="RedirectStandardOutput"/>.
    /// </remarks>
    public Action<string> StandardOutputAction { get; set; }

    /// <summary>
    /// Gets or sets the Log level set by Cake.
    /// </summary>
    internal Verbosity? CakeVerbosityLevel { get; set; }

    /// <summary>
    /// Gets the command which should be run.
    /// </summary>
    protected string Command { get; private set; } = command;

    /// <summary>
    /// Evaluates the settings and writes them to <paramref name="args"/>.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    internal void Evaluate(ProcessArgumentBuilder args)
    {
        args.Append(Command);
        AppendNpmSettings(args);
        EvaluateCore(args);
    }

    /// <summary>
    /// Evaluates the settings and appends Npm specific options to arguments
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    private void AppendNpmSettings(ProcessArgumentBuilder args) => AppendLogLevel(args, LogLevel);

    /// <summary>
    /// Evaluates the settings and writes them to <paramref name="args"/>.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    protected virtual void EvaluateCore(ProcessArgumentBuilder args)
    {
    }

    private void AppendLogLevel(ProcessArgumentBuilder args, NpmLogLevel logLevel)
    {
        if (logLevel == NpmLogLevel.Default && CakeVerbosityLevel.HasValue)
        {
            logLevel = CakeToNpmLogLevelConverter(CakeVerbosityLevel.Value);
        }

        switch (logLevel)
        {
            case NpmLogLevel.Default:
                break;
            case NpmLogLevel.Silent:
                args.Append("--silent");
                break;
            case NpmLogLevel.Warn:
                args.Append("--warn");
                break;
            case NpmLogLevel.Info:
                args.Append("--loglevel info");
                break;
            case NpmLogLevel.Verbose:
                args.Append("--loglevel verbose");
                break;
            case NpmLogLevel.Silly:
                args.Append("--loglevel silly");
                break;
            case NpmLogLevel.Error:
                args.Append("--loglevel error");
                break;
            case NpmLogLevel.Http:
                args.Append("--loglevel http");
                break;
        }
    }

    private static NpmLogLevel CakeToNpmLogLevelConverter(Verbosity cakeVerbosityLevel)
        => cakeVerbosityLevel switch
        {
            Verbosity.Quiet => NpmLogLevel.Silent,
            Verbosity.Minimal => NpmLogLevel.Warn,
            Verbosity.Verbose => NpmLogLevel.Info,
            Verbosity.Diagnostic => NpmLogLevel.Verbose,
            _ => NpmLogLevel.Default,
        };
}
