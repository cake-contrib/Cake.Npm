namespace Cake.Npm.Update
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmUpdateSettings"/>.
    /// </summary>
    public static class NpmUpdateSettingsExtensions
    {
        /// <summary>
        /// Will update globally installed packages
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmUpdateSettings.Global"/> set to <c>true</c>.</returns>
        public static NpmUpdateSettings UpdateGlobalPackages(this NpmUpdateSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Global = true;
            return settings;
        }
    }
}
