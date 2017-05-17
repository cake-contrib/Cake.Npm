namespace Cake.Npm
{
    using System;
    using Cake.Core.IO;

    /// <summary>
    /// Extensions for <see cref="NpmSettings"/>.
    /// </summary>
    public static class NpmSettingsExtensions
    {
        /// <summary>
        /// Sets the log level which should be used to run the npm command.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="logLevel">Log level which should be used to run the npm command.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.LogLevel"/> set to <paramref name="logLevel"/>.</returns>
        public static NpmSettings WithLogLevel(this NpmSettings settings, NpmLogLevel logLevel)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            settings.LogLevel = logLevel;

            return settings;
        }

        /// <summary>
        /// Sets the working directory which should be used to run the npm command.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="path">Working directory which should be used to run the npm command.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.WorkingDirectory"/> set to <paramref name="path"/>.</returns>
        public static NpmSettings FromPath(this NpmSettings settings, DirectoryPath path)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (path == null)
            {
                throw new ArgumentNullException(nameof(path));
            }

            settings.WorkingDirectory = path;

            return settings;
        }
    }
}
