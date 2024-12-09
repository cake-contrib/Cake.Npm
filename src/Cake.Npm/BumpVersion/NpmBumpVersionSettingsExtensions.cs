namespace Cake.Npm.BumpVersion
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmBumpVersionSettings"/>.
    /// </summary>
    public static class NpmBumpVersionSettingsExtensions
    {
        /// <summary>
        /// Defines that npm version should commit, even if the repository is not clean.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="force">Whether to set force, or not.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmBumpVersionSettings.Force"/> set.</returns>
        public static NpmBumpVersionSettings WithForce(this NpmBumpVersionSettings settings, bool force = true)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Force = force;
            return settings;
        }

        /// <summary>
        /// Sets the commit message. 
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="message">The commit message to set.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmBumpVersionSettings.CommitMessage"/> set.</returns>
        public static NpmBumpVersionSettings WithCommitMessage(this NpmBumpVersionSettings settings, string message)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.CommitMessage = message;
            return settings;
        }

        /// <summary>
        /// Sets the version to bump.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="version">The version to bump.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmBumpVersionSettings.CommitMessage"/> set.</returns>
        public static NpmBumpVersionSettings WithVersion(this NpmBumpVersionSettings settings, string version)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Version = version;
            return settings;
        }
    }
}
