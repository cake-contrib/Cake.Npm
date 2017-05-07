namespace Cake.Npm.RunScript
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmRunScriptSettings"/>.
    /// </summary>
    public static class NpmRunScriptSettingsExtensions
    {
        /// <summary>
        /// Sets the arguments which should be passed to the script.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="arguments">Arguments which should be passed to the script.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmRunScriptSettings.Arguments"/> set to <paramref name="arguments"/>.</returns>
		public static NpmRunScriptSettings WithArguments(this NpmRunScriptSettings settings, string arguments)
		{
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrWhiteSpace(arguments))
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            settings.Arguments.Add(arguments);

			return settings;
		}
    }
}
