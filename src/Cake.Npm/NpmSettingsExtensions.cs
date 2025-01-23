namespace Cake.Npm;

using System;
using Cake.Core.IO;

/// <summary>
/// Extensions for <see cref="NpmSettings"/>.
/// </summary>
public static class NpmSettingsExtensions
{
    /// <summary>
    /// Sets the log level which should be used to run the npm command.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="logLevel">Log level which should be used to run the npm command.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.LogLevel"/> set to <paramref name="logLevel"/>.</returns>
    public static NpmSettings WithLogLevel(this NpmSettings settings, NpmLogLevel logLevel)
    {
        ArgumentNullException.ThrowIfNull(settings);

        settings.LogLevel = logLevel;

        return settings;
    }

    /// <summary>
    /// Sets the working directory which should be used to run the npm command.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="path">Working directory which should be used to run the npm command.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="Core.Tooling.ToolSettings.WorkingDirectory"/> set to <paramref name="path"/>.</returns>
    public static NpmSettings FromPath(this NpmSettings settings, DirectoryPath path)
    {
        ArgumentNullException.ThrowIfNull(settings);

        settings.WorkingDirectory = path ?? throw new ArgumentNullException(nameof(path));

        return settings;
    }

    /// <summary>
    /// Sets the StandardError-Action
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="standardErrorAction">The StandardError-Action.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.StandardErrorAction"/> set to <paramref name="standardErrorAction"/>.</returns>
    public static NpmSettings SetRedirectedStandardErrorHandler(this NpmSettings settings, Action<string> standardErrorAction)
    {
        ArgumentNullException.ThrowIfNull(settings);

        settings.StandardErrorAction = standardErrorAction ?? throw new ArgumentNullException(nameof(standardErrorAction));

        return settings;
    }

    /// <summary>
    /// Sets the StandardOutput-Action
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="standardOutputAction">The StandardOutput-Action.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.StandardOutputAction"/> set to <paramref name="standardOutputAction"/>.</returns>
    public static NpmSettings SetRedirectedStandardOutputHandler(this NpmSettings settings, Action<string> standardOutputAction)
    {
        ArgumentNullException.ThrowIfNull(settings);

        settings.StandardOutputAction = standardOutputAction ?? throw new ArgumentNullException(nameof(standardOutputAction));

        return settings;
    }
}
