namespace Cake.Npm.Install
{
    using System;
    using Core;

    /// <summary>
    /// Extensions for <see cref="NpmInstallSettings"/>.
    /// </summary>
    public static class NpmInstallSettingsExtensions
    {
        /// <summary>
        /// Defines that npm should fetch remote resources even if a local copy
        /// exists on disk.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.Force"/> set to <c>true</c>.</returns>
        public static NpmInstallSettings WithForce(this NpmInstallSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            return settings.WithForce(true);
        }

        /// <summary>
        /// Defines that npm should not fetch remote resources if a local copy exists on disk.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.Force"/> set to <c>false</c>.</returns>
        public static NpmInstallSettings WithoutForce(this NpmInstallSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            return settings.WithForce(false);
        }

        /// <summary>
        /// Defines whether npm should fetch remote resources even if a local copy
        /// exists on disk.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="value">Value which should be set.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.Force"/> set to <paramref name="value"/>.</returns>
        public static NpmInstallSettings WithForce(this NpmInstallSettings settings, bool value)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Force = value;
            return settings;
        }

        /// <summary>
        /// Defines that the package should be installed globally.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.Global"/> set to <c>true</c>.</returns>
        public static NpmInstallSettings InstallGlobally(this NpmInstallSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Global = true;
            return settings;
        }

        /// <summary>
        /// Defines that the package should be installed locally.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.Global"/> set to <c>false</c>.</returns>
        public static NpmInstallSettings InstallLocally(this NpmInstallSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Global = false;
            return settings;
        }

        /// <summary>
        /// Defines that npm should ignore modules listed in <c>devDependencies</c>.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.Production"/> set to <c>true</c>.</returns>
        public static NpmInstallSettings ForProduction(this NpmInstallSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Production = true;
            return settings;
        }

        /// <summary>
        /// Defines that npm should prevent optional dependencies from being installed
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.NoOptional"/> set to <c>true</c>.</returns>
        public static NpmInstallSettings WithoutOptionalDependencies(this NpmInstallSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            return settings.WithNoOptional(true);
        }

        /// <summary>
        /// Defines that npm should install optional dependencies
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.NoOptional"/> set to <c>false</c>.</returns>
        public static NpmInstallSettings WithOptionalDependencies(this NpmInstallSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            return settings.WithNoOptional(false);
        }

        /// <summary>
        /// Defines whether npm should prevent optional dependencies from being installed
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="value">Value which should be set.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.NoOptional"/> set to <paramref name="value"/>.</returns>
        public static NpmInstallSettings WithNoOptional(this NpmInstallSettings settings, bool value)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.NoOptional = value;
            return settings;
        }

        /// <summary>
        /// Install a package from a specific url.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="url">Url to directory containing package.json (see npm docs)</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="url"/> added to <see cref="NpmInstallSettings.Packages"/>.</returns>
        public static NpmInstallSettings AddPackage(this NpmInstallSettings settings, Uri url)
        {
            ArgumentNullException.ThrowIfNull(settings);

            ArgumentNullException.ThrowIfNull(url);

            if (!url.IsAbsoluteUri)
            {
                throw new UriFormatException("Must be to an absolute url to the npm package.");
            }

            settings.Packages.Add(url.AbsoluteUri);
            return settings;
        }

        /// <summary>
        /// Install a package by name, version/tag.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="packageName"/> added to <see cref="NpmInstallSettings.Packages"/>.</returns>
        public static NpmInstallSettings AddPackage(this NpmInstallSettings settings, string packageName)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            return settings.AddPackage(packageName, null, null);
        }

        /// <summary>
        /// Install a package by name and version/tag.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="versionOrTag">Version or tag published to the registry.</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="packageName"/> added to <see cref="NpmInstallSettings.Packages"/>.</returns>
        public static NpmInstallSettings AddPackage(this NpmInstallSettings settings, string packageName, string versionOrTag)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(versionOrTag))
            {
                throw new ArgumentNullException(nameof(versionOrTag));
            }

            return settings.AddPackage(packageName, null, versionOrTag);
        }

        /// <summary>
        /// Install a scoped package by name, version/tag.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="scope">Scope of the package.</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="packageName"/> added to <see cref="NpmInstallSettings.Packages"/>.</returns>
        public static NpmInstallSettings AddScopedPackage(this NpmInstallSettings settings, string packageName, string scope)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(scope))
            {
                throw new ArgumentNullException(nameof(scope));
            }

            return settings.AddPackage(packageName, scope, null);
        }

        /// <summary>
        /// Install a package by name, version/tag and scope.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="scope">Scope of the package. Null for not restricting to a scope.</param>
        /// <param name="versionOrTag">Version or tag published to the registry. Null for latest version.</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="packageName"/> added to <see cref="NpmInstallSettings.Packages"/>.</returns>
        public static NpmInstallSettings AddPackage(this NpmInstallSettings settings, string packageName, string scope, string versionOrTag)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            var resolvedPackageName = packageName;

            if (!string.IsNullOrWhiteSpace(versionOrTag))
            {
                var versionOrTagValue = versionOrTag;
                if (versionOrTagValue.Contains(' '))
                {
                    versionOrTagValue = versionOrTag.Quote();
                }
                resolvedPackageName = $"{packageName}@{versionOrTagValue}";
            }

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

        /// <summary>
        /// Instructs npm to look for packages in the given registry.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="registry">The registry to look up packages from</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmInstallSettings.Registry"/> set to <paramref name="registry" />.</returns>
        public static NpmInstallSettings FromRegistry(this NpmInstallSettings settings, Uri registry)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            return settings;
        }
    }
}
