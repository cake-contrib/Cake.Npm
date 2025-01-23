namespace Cake.Npm.Rebuild;

using System.Collections.Generic;
using Core;
using Core.IO;

/// <summary>
/// Contains settings used by <see cref="NpmRebuilder"/>
/// </summary>
public class NpmRebuildSettings : NpmSettings
{
    private readonly List<string> _packages = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="NpmRebuildSettings"/> class.
    /// </summary>
    public NpmRebuildSettings() : base("rebuild")
    {
    }

    /// <summary>
    /// Gets the list of packages which should be rebuilt
    /// </summary>
    public IList<string> Packages => _packages;

    /// <summary>
    /// Evaluates the settings and writes them to <paramref name="args"/>.
    /// </summary>
    /// <param name="args">The argument builder into which the settings should be written.</param>
    protected override void EvaluateCore(ProcessArgumentBuilder args)
    {
        base.EvaluateCore(args);

        foreach (var package in Packages)
        {
            ProcessArgumentListExtensions.Append(args, package);
        }
    }
}