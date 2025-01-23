namespace Cake.Npm.ViewVersion;

using Core;
using Core.IO;

using System;

/// <summary>
/// Contains settings used by <see cref="NpmViewVersionTool"/>.
/// </summary>
public class NpmViewVersionSettings : NpmSettings
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NpmViewVersionSettings"/> class.
    /// </summary>
    public NpmViewVersionSettings()
        : base("view")
    {
        // Since 'NpmViewVersion' returns a string we should redirect standard output.
        RedirectStandardOutput = true;
        Package = "npm";
    }

    /// <summary>
    /// Gets or sets the package to view the version of.
    /// </summary>
    /// <value>
    /// The package.
    /// </value>
    public string Package { get; set; }

    /// <summary>
    /// Evaluates the settings and writes them to <paramref name="args"/>.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        if (string.IsNullOrEmpty(Package))
        {
            throw new ArgumentOutOfRangeException(nameof(Package));
        }

        base.EvaluateCore(args);
        args.Append(Package);
        args.Append("version");
    }
}
