namespace Cake.Npm
{
    using System;
    using BumpVersion;
    using Core;
    using Core.Annotations;

    /// <summary>
    /// Npm BumpVersion aliases. 
    /// Use this if you want to use 'npm version' to bump the version.
    /// Use this to bump the version of the current package.
    /// For other functions of npm version, see:
    /// <list type="bullet">
    ///   <item><description><see cref="NpmViewVersionAliases"/></description></item>
    ///   <item><description><see cref="NpmVersionAliases"/></description></item>
    /// </list>
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.BumpVersion")]
    public static class NpmBumpVersionAliases
    {
        /// <summary>
        /// Bump the version of the package.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmBumpVersion();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("BumpVersion")]
        public static void NpmBumpVersion(this ICakeContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.NpmBumpVersion(new NpmBumpVersionSettings());
        }

        /// <summary>
        /// Bump the version of the package using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmBumpVersion(settings => 
        ///         settings.Version("major"));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("BumpVersion")]
        public static void NpmBumpVersion(this ICakeContext context, Action<NpmBumpVersionSettings> configurator)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(configurator);

            var settings = new NpmBumpVersionSettings();
            configurator(settings);
            context.NpmBumpVersion(settings);
        }

        /// <summary>
        /// Bump the version of the package using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var settings = new NpmBumpVersionSettings();
        ///     settings.Version = "major";
        ///     NpmBumpVersion(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("BumpVersion")]
        public static void NpmBumpVersion(this ICakeContext context, NpmBumpVersionSettings settings)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(settings);

            AddinInformation.LogVersionInformation(context.Log);
            var tool = new NpmBumpVersionTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            tool.BumpVersion(settings);
        }
    }
}