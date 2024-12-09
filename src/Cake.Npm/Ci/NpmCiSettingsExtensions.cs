namespace Cake.Npm.Ci
{
    using Cake.Npm.Ci;
    using System;
    using Cake.Core;

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
            ArgumentNullException.ThrowIfNull(settings);

            settings.Production = true;
            return settings;
        }

        /// <summary>
        /// Instructs npm to look for packages in the given registry.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="registry">The registry to look up packages from</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmCiSettings.Registry"/> set to <paramref name="registry" />.</returns>
        public static NpmCiSettings FromRegistry(this NpmCiSettings settings, Uri registry)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            return settings;
        }
    }
}
