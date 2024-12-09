namespace Cake.Npm.Publish
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmPublishSettings"/>.
    /// </summary>
    public static class NpmPublishSettingsExtensions
    {
        /// <summary>
        /// Sets the source to publish.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="source">Source to publish.
        /// A folder containing a package.json file or an url or file path to a gzipped tar archive 
        /// containing a single folder with a package.json file inside.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPublishSettings.Source"/> set to <paramref name="source"/>.</returns>
        public static NpmPublishSettings FromSource(this NpmPublishSettings settings, string source)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            settings.Source = source;

            return settings;
        }

        /// <summary>
        /// Sets the tag of the package to publish.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="tag">Tag with which the package will be published.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPublishSettings.Tag"/> set to <paramref name="tag"/>.</returns>
        public static NpmPublishSettings WithTag(this NpmPublishSettings settings, string tag)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            settings.Tag = tag;

            return settings;
        }

        /// <summary>
        /// Sets the access of the published package.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="access">Access of the published package.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPublishSettings.Access"/> set to <paramref name="access"/>.</returns>
        public static NpmPublishSettings WithAccess(this NpmPublishSettings settings, NpmPublishAccess access)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Access = access;

            return settings;
        }

        /// <summary>
        /// Sets the registry where the package will be published to.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="registry">Registry where the package will be published to.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmPublishSettings.Registry"/> set to <paramref name="registry"/>.</returns>
        public static NpmPublishSettings ToRegistry(this NpmPublishSettings settings, Uri registry)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Registry = registry ?? throw new ArgumentNullException(nameof(registry));

            return settings;
        }
    }
}
