namespace Cake.Npm.Rebuild
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmRebuildSettings"/>.
    /// </summary>
    public static class NpmRebuildSettingsExtensions
    {
        /// <summary>
        /// Rebuild a package by name
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="packageName"/> added to <see cref="NpmRebuildSettings.Packages"/>.</returns>
        public static NpmRebuildSettings AddPackage(this NpmRebuildSettings settings, string packageName)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            return settings.AddScopedPackage(packageName, null);
        }

        /// <summary>
        /// Rebuild a scoped package by name
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="scope">Scope of the package.</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="packageName"/> added to <see cref="NpmRebuildSettings.Packages"/>.</returns>
        public static NpmRebuildSettings AddScopedPackage(this NpmRebuildSettings settings, string packageName, string scope)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            var resolvedPackageName = packageName;

            if (!string.IsNullOrWhiteSpace(scope))
            {
                if (!scope.StartsWith('@'))
                {
                    throw new ArgumentException("Scope should start with @", nameof(scope));
                }

                resolvedPackageName =
                    !string.IsNullOrWhiteSpace(scope) ? $"{scope}/{resolvedPackageName}" : resolvedPackageName;
            }

            settings.Packages.Add(resolvedPackageName);
            return settings;
        }
    }
}