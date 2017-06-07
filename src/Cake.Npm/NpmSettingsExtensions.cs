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
        /// <returns>The <paramref name="settings"/> instance with <see cref="Core.Tooling.ToolSettings.WorkingDirectory"/> set to <paramref name="path"/>.</returns>
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

        /// <summary>
        /// Sets the arguments which should be passed to npm.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="arguments">Arguments which should be passed to the script.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.NpmArguments"/> set to <paramref name="arguments"/>.</returns>
        public static NpmSettings WithNpmArguments(this NpmSettings settings, string arguments)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(arguments))
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            settings.NpmArguments.Add(arguments);

            return settings;
        }
    }
}
