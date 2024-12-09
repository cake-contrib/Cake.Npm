namespace Cake.Npm.Pack
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmPackSettings"/>.
    /// </summary>
    public static class NpmPackSettingsExtensions
    {
        /// <summary>
        /// Sets the source to pack.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="source">Source to pack.
        /// Can be anything that is installable by npm, like a package folder, tarball, tarball url,
        /// name@tag, name@version, name, or scoped name.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPackSettings.Source"/> set to <paramref name="source"/>.</returns>
        public static NpmPackSettings FromSource(this NpmPackSettings settings, string source)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            settings.Source = source;

            return settings;
        }
    }
}
