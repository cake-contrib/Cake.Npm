namespace Cake.Npm.ViewVersion
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmViewVersionSettings"/>.
    /// </summary>
    public static class NpmViewVersionSettingsExtensions
    {
        /// <summary>
        /// Sets the package to view the version of.
        /// exists on disk.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="package">The package for which to view the version.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmViewVersionSettings.Package"/> set.</returns>
        public static NpmViewVersionSettings ForPackage(this NpmViewVersionSettings settings, string package)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Package = package;
            return settings;
        }
    }
}
