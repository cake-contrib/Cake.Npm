namespace Cake.Npm.DistTag
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmDistTagAddSettings"/>.
    /// </summary>
    public static class NpmDistTagAddSettingsExtensions
    {
        /// <summary>
        /// Sets the tag which should be set on the package.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="tag">Tag with which should be set on the package.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmDistTagAddSettings.Tag"/> set to <paramref name="tag"/>.</returns>
        public static NpmDistTagAddSettings WithTag(this NpmDistTagAddSettings settings, string tag)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            settings.Tag = tag;

            return settings;
        }
    }
}
