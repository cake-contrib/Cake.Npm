namespace Cake.Npm.AddUser
{
    using System;

    /// <summary>
    /// Extensions for <see cref="NpmAddUserSettings"/>.
    /// </summary>
    public static class NpmAddUserSettingsExtensions
    {
        /// <summary>
        /// Instructs npm to add user for the given registry.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="registry">The registry for the user.</param>
        /// <returns>The <paramref name="settings"/> instance with <see cref="NpmAddUserSettings.Registry"/> set to <paramref name="registry" />.</returns>
        public static NpmAddUserSettings ForRegistry(this NpmAddUserSettings settings, Uri registry)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.Registry = registry ?? throw new ArgumentNullException(nameof(registry));
            return settings;
        }

        /// <summary>
        /// Sets scope for credentials.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="scope">Scope of credentials. Scope must start with an @.</param>
        /// <returns>The <paramref name="settings"/> instance with <paramref name="scope"/> added to <see cref="NpmAddUserSettings.Scope"/>.</returns>
        public static NpmAddUserSettings ForScope(this NpmAddUserSettings settings, string scope)
        {
            ArgumentNullException.ThrowIfNull(settings);

            if (string.IsNullOrWhiteSpace(scope))
            {
                throw new ArgumentNullException(nameof(scope));
            }

            if (!scope.StartsWith('@'))
            {
                throw new ArgumentException("Scope should start with @", nameof(scope));
            }
            settings.Scope = scope;
            return settings;
        }

        /// <summary>
        /// Force npm to always require authentication when accessing the registry, even for GET requests.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The <see cref="NpmAddUserSettings"/> instance with AlwaysAuth set to true.</returns>
        public static NpmAddUserSettings AlwaysAuthenticate(this NpmAddUserSettings settings)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.AlwaysAuth = true;
            return settings;
        }

        /// <summary>
        /// Defines the authentication strategy to use.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="authType">The authentication type.</param>
        /// <returns>The <see cref="NpmAddUserSettings"/> instance with <paramref name="authType"/> added to <see cref="NpmAddUserSettings.AuthType"/>.</returns>
        public static NpmAddUserSettings UsingAuthentication(this NpmAddUserSettings settings, AuthType authType)
        {
            ArgumentNullException.ThrowIfNull(settings);

            settings.AuthType = authType;
            return settings;
        }
    }
}
