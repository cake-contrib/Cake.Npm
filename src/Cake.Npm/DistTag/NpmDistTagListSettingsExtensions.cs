namespace Cake.Npm.DistTag
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmDistTagListSettings"/>.
    /// </summary>
    public static class NpmDistTagListSettingsExtensions
    {
        /// <summary>
        /// Sets the name of the package for which tags should be listed.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="packageName">Tag with which should be set on the package.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmDistTagAddSettings.PackageName"/> set to <paramref name="packageName"/>.</returns>
        public static NpmDistTagListSettings ForPackage(this NpmDistTagListSettings settings, string packageName)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            settings.PackageName = packageName;

            return settings;
        }
    }
}
