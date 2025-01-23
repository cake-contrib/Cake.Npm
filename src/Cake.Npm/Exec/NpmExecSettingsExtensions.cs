namespace Cake.Npm.Exec;

using System;

/// <summary>
/// Extensions for <see cref="NpmExecSettings" />.
/// </summary>
public static class NpmExecSettingsExtensions
{
    /// <summary>
    /// Sets the arguments which should be passed to the script.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="arguments">Arguments which should be passed to the script.</param>
    /// <returns>
    /// The <paramref name="settings" /> instance with <see cref="NpmExecSettings.Arguments" /> set to
    /// <paramref name="arguments" />.
    /// </returns>
    public static NpmExecSettings WithArguments(this NpmExecSettings settings, string arguments)
    {
        ArgumentNullException.ThrowIfNull(settings);

        if (string.IsNullOrWhiteSpace(arguments))
        {
            throw new ArgumentNullException(nameof(arguments));
        }

        settings.Arguments.Add(arguments);

        return settings;
    }
}