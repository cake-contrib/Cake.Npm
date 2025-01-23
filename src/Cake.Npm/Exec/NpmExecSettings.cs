namespace Cake.Npm.Exec;

using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

/// <summary>
/// Contains settings used by <see cref="NpmExecRunner" />.
/// </summary>
public class NpmExecSettings : NpmSettings
{
    private readonly List<string> arguments = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="NpmExecSettings" /> class.
    /// </summary>
    public NpmExecSettings()
        : base("exec")
    {
    }

    /// <summary>
    /// Name of the script to execute as defined in package.json.
    /// </summary>
    public string ExecCommand { get; set; }

    /// <summary>
    /// Arguments to pass to the target script.
    /// </summary>
    public IList<string> Arguments => arguments;

    /// <inheritdoc />
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (string.IsNullOrEmpty(ExecCommand))
        {
            throw new InvalidOperationException("Must provide a command to execute.");
        }

        base.EvaluateCore(args);

        args.AppendQuoted(ExecCommand);

        if (Arguments.Any())
        {
            args.Append("--");
            foreach (var arg in Arguments) args.Append(arg);
        }
    }
}