namespace Cake.Npm;

using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.Prune;
using System;

/// <summary>
/// Npm Prune aliases
/// </summary>
[CakeAliasCategory("Npm")]
[CakeNamespaceImport("Cake.Npm.Prune")]
public static class NpmPruneAliases
{

    /// <summary>
    /// Runs npm prune from the current folder.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     NpmPrune();
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Prune")]
    public static void NpmPrune(this ICakeContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        context.NpmPrune(new NpmPruneSettings());
    }

    /// <summary>
    /// Runs npm prune using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <example>
    /// <para>Use specific log level</para>
    /// <code>
    /// <![CDATA[
    ///     NpmPrune(settings => settings.WithLogLevel(NpmLogLevel.Verbose));
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Prune")]
    public static void NpmPrune(this ICakeContext context, Action<NpmPruneSettings> configurator)
    {
        ArgumentNullException.ThrowIfNull(context);

        ArgumentNullException.ThrowIfNull(configurator);

        var settings = new NpmPruneSettings();
        configurator(settings);
        context.NpmPrune(settings);
    }

    /// <summary>
    /// Runs npm prune with the specified settings.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings.</param>
    /// <example>
    /// <para>Use specific log level</para>
    /// <code>
    /// <![CDATA[
    ///     var settings = 
    ///         new NpmPruneSettings 
    ///         {
    ///             LogLevel = NpmLogLevel.Verbose
    ///         };
    ///     NpmPrune(settings);
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Prune")]
    public static void NpmPrune(this ICakeContext context, NpmPruneSettings settings)
    {
        ArgumentNullException.ThrowIfNull(context);

        ArgumentNullException.ThrowIfNull(settings);

        AddinInformation.LogVersionInformation(context.Log);

        var pruner = new NpmPruneRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
        pruner.Prune(settings);
    }
}