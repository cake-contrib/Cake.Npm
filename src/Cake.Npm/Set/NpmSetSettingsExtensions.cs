namespace Cake.Npm.Set;

using System;

/// <summary>
/// Extensions for <see cref="NpmSetSettings"/>.
/// </summary>
public static class NpmSetSettingsExtensions
{
    /// <summary>
    /// Defines the key which should be set.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="key">Key which should be set.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSetSettings.Key"/> set to <paramref name="key"/>.</returns>
    public static NpmSetSettings ForKey(this NpmSetSettings settings, string key)
    {
        ArgumentNullException.ThrowIfNull(settings);

        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentNullException(nameof(key));
        }

        settings.Key = key;
        return settings;
    }

    /// <summary>
    /// Defines the value which should be set.
    /// </summary>
    /// <param name="settings">The settings.</param>
    /// <param name="value">Value which should be set.</param>
    /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSetSettings.Value"/> set to <paramref name="value"/>.</returns>
    public static NpmSetSettings WithValue(this NpmSetSettings settings, string value)
    {
        ArgumentNullException.ThrowIfNull(settings);

        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentNullException(nameof(value));
        }

        settings.Value = value;
        return settings;
    }
}
