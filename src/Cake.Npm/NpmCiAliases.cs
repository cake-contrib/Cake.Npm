namespace Cake.Npm;

using System;
using Cake.Npm.Ci;
using Core;
using Core.Annotations;

/// <summary>
/// Npm Ci aliases
/// </summary>
[CakeAliasCategory("Npm")]
[CakeNamespaceImport("Cake.Npm.Ci")]
public static class NpmCiAliases
{
    /// <summary>
    /// Cis all packages for the project in the current working directory.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     NpmCi();
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Ci")]
    public static void NpmCi(this ICakeContext context)
    {
        ArgumentNullException.ThrowIfNull(context);

        context.NpmCi(new NpmCiSettings());
    }

    /// <summary>
    /// Cis packages using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <example>
    /// <para>Use specific log level ('npm ci')</para>
    /// <code>
    /// <![CDATA[
    ///     NpmCi(settings => settings.WithLogLevel(NpmLogLevel.Verbose));
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Ci")]
    public static void NpmCi(this ICakeContext context, Action<NpmCiSettings> configurator)
    {
        ArgumentNullException.ThrowIfNull(context);

        ArgumentNullException.ThrowIfNull(configurator);

        var settings = new NpmCiSettings();
        configurator(settings);
        context.NpmCi(settings);
    }

    /// <summary>
    /// Cis packages using the specified settings.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings.</param>
    /// <example>
    /// <para>Use specific log level ('npm ci')</para>
    /// <code>
    /// <![CDATA[
    ///     var settings = 
    ///         new NpmCiSettings 
    ///         {
    ///             LogLevel = NpmLogLevel.Verbose
    ///         };
    ///     NpmCi(settings);
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Ci")]
    public static void NpmCi(this ICakeContext context, NpmCiSettings settings)
    {
        ArgumentNullException.ThrowIfNull(context);

        ArgumentNullException.ThrowIfNull(settings);

        AddinInformation.LogVersionInformation(context.Log);
        var ciTool = new NpmCiTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
        ciTool.Install(settings);
    }
}