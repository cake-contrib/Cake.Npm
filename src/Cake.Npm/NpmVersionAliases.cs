namespace Cake.Npm
{
    using System;
    using Cake.Npm.Version;
    using Core;
    using Core.Annotations;

    /// <summary>
    /// Npm Version aliases.
    /// Use this to get the current npm version in use.
    /// For other functions of npm version, see:
    /// <list type="bullet">
    ///   <item><description><see cref="NpmViewVersionAliases"/></description></item>
    ///   <item><description><see cref="NpmBumpVersionAliases"/></description></item>
    /// </list>
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Version")]
    public static class NpmVersionAliases
    {
        /// <summary>
        /// Versions all packages for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var versionString = NpmVersion();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmVersion(this ICakeContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            AddinInformation.LogVersionInformation(context.Log);
            return context.NpmVersion(new NpmVersionSettings());
        }

        /// <summary>
        /// Versions all packages for the project in the current working directory
        /// using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var versionString = NpmVersion(settings => settings.WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmVersion(this ICakeContext context, Action<NpmVersionSettings> configurator)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(configurator);

            var settings = new NpmVersionSettings();
            configurator(settings);
            return context.NpmVersion(settings);
        }

        /// <summary>
        /// Versions all packages for the project in the current working directory
        /// using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var settings = new NpmVersionSettings();
        ///     settings.WithLogLevel(NpmLogLevel.Verbose);
        ///     var versionString = NpmVersion(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmVersion(this ICakeContext context, NpmVersionSettings settings)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(settings);

            AddinInformation.LogVersionInformation(context.Log);
            var tool = new NpmVersionTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            return tool.Version(settings);
        }
    }
}