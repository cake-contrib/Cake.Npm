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
        /// Sets the StandardError-Action
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="standardErrorAction">The StandardError-Action.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.StandardErrorAction"/> set to <paramref name="standardErrorAction"/>.</returns>
        public static NpmSettings SetRedirectedStandardErrorHandler(this NpmSettings settings, Action<string> standardErrorAction)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (standardErrorAction == null)
            {
                throw new ArgumentNullException(nameof(standardErrorAction));
            }

            settings.StandardErrorAction = standardErrorAction;

            return settings;
        }

        /// <summary>
        /// Sets the StandardOutput-Action
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="standardOutputAction">The StandardOutput-Action.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmSettings.StandardOutputAction"/> set to <paramref name="standardOutputAction"/>.</returns>
        public static NpmSettings SetRedirectedStandardOutputHandler(this NpmSettings settings, Action<string> standardOutputAction)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (standardOutputAction == null)
            {
                throw new ArgumentNullException(nameof(standardOutputAction));
            }

            settings.StandardOutputAction = standardOutputAction;

            return settings;
        }
    }
}
