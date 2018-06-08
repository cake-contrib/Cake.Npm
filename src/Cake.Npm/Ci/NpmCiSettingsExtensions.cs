using Cake.Npm.Ci;

namespace Cake.Npm.Install
{
    using System;
    using Core;

    /// <summary>
    /// Extensions for <see cref="NpmCiSettings"/>.
    /// </summary>
    public static class NpmCiSettingsExtensions
    {

        /// <summary>
        /// Defines that npm should ignore modules listed in <c>devDependencies</c>.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmCiSettings.Production"/> set to <c>true</c>.</returns>
        public static NpmCiSettings ForProduction(this NpmCiSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.Production = true;
            return settings;
        }
    }
}
