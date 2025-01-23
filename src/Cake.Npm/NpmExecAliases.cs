using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.Exec;

namespace Cake.Npm;

/// <summary>
/// Npm exec aliases
/// </summary>
[CakeAliasCategory("Npm")]
[CakeNamespaceImport("Cake.Npm.Exec")]
public static class NpmExecAliases
{
    /// <summary>
    /// Runs an npm exec command.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="command">Command to execute.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     NpmExec("hello");
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Exec")]
    public static void NpmExec(this ICakeContext context, string command)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (string.IsNullOrWhiteSpace(command))
        {
            throw new ArgumentNullException(nameof(command));
        }

        context.NpmExec(
            new NpmExecSettings
            {
                ExecCommand = command
            });
    }

    /// <summary>
    /// Runs an npm exec command.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="command">Command to execute.</param>
    /// <param name="arguments">Arguments to pass to the target command.</param>
    /// <example>
    /// <code>
    /// <![CDATA[
    ///     NpmExec("hello", new List<string> { "--foo=bar" });
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Exec")]
    public static void NpmExec(this ICakeContext context, string command, IEnumerable<string> arguments)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (string.IsNullOrWhiteSpace(command))
        {
            throw new ArgumentNullException(nameof(command));
        }

        ArgumentNullException.ThrowIfNull(arguments);

        var settings = new NpmExecSettings
        {
            ExecCommand = command
        };

        foreach (var argument in arguments) settings.Arguments.Add(argument);

        context.NpmExec(settings);
    }

    /// <summary>
    /// Runs an npm exec command using the settings returned by a configurator.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="command">Command to execute.</param>
    /// <param name="configurator">The settings configurator.</param>
    /// <example>
    /// <para>Use specific log level</para>
    /// <code>
    /// <![CDATA[
    ///     NpmExec("hello", settings => settings.WithLogLevel(NpmLogLevel.Verbose));
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Exec")]
    public static void NpmExec(this ICakeContext context, string command,
        Action<NpmExecSettings> configurator)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (string.IsNullOrWhiteSpace(command))
        {
            throw new ArgumentNullException(nameof(command));
        }

        ArgumentNullException.ThrowIfNull(configurator);

        var settings = new NpmExecSettings { ExecCommand = command };
        configurator(settings);
        context.NpmExec(settings);
    }

    /// <summary>
    /// Runs an npm exec command with the specified settings.
    /// </summary>
    /// <param name="context">The context.</param>
    /// <param name="settings">The settings.</param>
    /// <example>
    /// <para>Use specific log level</para>
    /// <code>
    /// <![CDATA[
    ///     var settings = 
    ///         new NpmExecSettings 
    ///         {
    ///             ExecCommand = "hello"
    ///             LogLevel = NpmLogLevel.Verbose
    ///         };
    ///     NpmExec(settings);
    /// ]]>
    /// </code>
    /// </example>
    [CakeMethodAlias]
    [CakeAliasCategory("Exec")]
    public static void NpmExec(this ICakeContext context, NpmExecSettings settings)
    {
        ArgumentNullException.ThrowIfNull(context);

        ArgumentNullException.ThrowIfNull(settings);

        AddinInformation.LogVersionInformation(context.Log);

        var packer = new NpmExecRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools,
            context.Log);
        packer.Exec(settings);
    }
}