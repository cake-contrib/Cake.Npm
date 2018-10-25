namespace Cake.Npm
{
    using System;
    using Core;
    using Core.Annotations;
    using AddUser;

    /// <summary>
    /// Npm Install aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.AddUser")]
    public static class NpmAddUserAliases
    {
        /// <summary>
        /// Adds user using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para>Base url of package registry ('npm adduser --registry=http://myregistry.example.com')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmAddUser(settings => setting.ForRegistry("http://myregistry.example.com"));
        /// ]]>
        /// </code>
        /// <para>Scope assoicated with the user ('npm adduser --scope=@cake')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmAddUser(settings => settings.ForScope("@cake"));
        /// ]]>
        /// </code>
        /// <para>Indicates that all requests to the given registry should include authorization information ('npm adduser --registry=http://private-registry.example.com --always-auth')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmAddUser(settings => settings.AlwaysAuthenticate());
        /// ]]>
        /// </code>
        /// <para>What authentication strategy to use ('npm adduser --auth-type=legacy')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmAddUser(settings => setting.UsingAuthentication(AuthType.Legacy));
        /// ]]>
        /// </code>
        /// <para>Use specific log level ('npm adduser')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmAddUser(settings => settings.WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("AddUser")]
        public static void NpmAddUser(this ICakeContext context, Action<NpmAddUserSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new NpmAddUserSettings();
            configurator(settings);
            context.NpmAddUser(settings);
        }

        /// <summary>
        /// Adds user using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Base url of package registry ('npm adduser --registry=http://myregistry.example.com')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmAddUserSettings 
        ///         {
        ///             Registry = "http://myregistry.example.com"
        ///         };
        ///     NpmAddUser(settings);
        /// ]]>
        /// </code>
        /// <para>Scope assoicated with the user ('npm adduser --scope=@cake')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmAddUserSettings 
        ///         {
        ///             Scope = "@cake"
        ///         };
        ///     NpmAddUser(settings);
        /// ]]>
        /// </code>
        /// <para>Indicates that all requests to the given registry should include authorization information ('npm adduser --registry=http://private-registry.example.com --always-auth')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmAddUserSettings 
        ///         {
        ///             AlwaysAuthenticate = true
        ///         };
        ///     NpmAddUser(settings);
        /// ]]>
        /// </code>
        /// <para>What authentication strategy to use ('npm adduser --auth-type=legacy')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmAddUserSettings 
        ///         {
        ///             AuthType = AuthType.Legacy
        ///         };
        ///     NpmAddUser(settings);
        /// ]]>
        /// </code>
        /// <para>Use specific log level ('npm adduser')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmAddUserSettings 
        ///         {
        ///             LogLevel = NpmLogLevel.Verbose
        ///         };
        ///     NpmAddUser(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("AddUser")]
        public static void NpmAddUser(this ICakeContext context, NpmAddUserSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            AddinInformation.LogVersionInformation(context.Log);
            var addUser = new NpmAddUser(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            addUser.AddUser(settings);
        }
    }
}