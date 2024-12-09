namespace Cake.Npm
{
    using System;
    using Cake.Core;
    using Cake.Core.Annotations;
    using Cake.Npm.ViewVersion;

    /// <summary>
    /// Npm ViewVersion aliases.
    /// Use this to view package versions.
    /// For other functions of npm version, see:
    /// <list type="bullet">
    ///   <item><description><see cref="NpmVersionAliases"/></description></item>
    ///   <item><description><see cref="NpmBumpVersionAliases"/></description></item>
    /// </list>
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.ViewVersion")]
    public static class NpmViewVersionAliases
    {
        /// <summary>
        /// View the version of a package.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="package">The Package.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var versionString = NpmViewVersion("cakejs");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmViewVersion(this ICakeContext context, string package)
        {
            ArgumentNullException.ThrowIfNull(context);

            AddinInformation.LogVersionInformation(context.Log);
            return context.NpmViewVersion(new NpmViewVersionSettings
            {
                Package = package
            });
        }

        /// <summary>
        /// View the version of a package
        /// using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var versionString = NpmViewVersion(settings => 
        ///         settings.ForPackage("cakejs"));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmViewVersion(this ICakeContext context, Action<NpmViewVersionSettings> configurator)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(configurator);

            var settings = new NpmViewVersionSettings();
            configurator(settings);
            return context.NpmViewVersion(settings);
        }

        /// <summary>
        /// View the version of a package
        /// using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var settings = new NpmViewVersionSettings();
        ///     settings.Package = "cakejs";
        ///     var versionString = NpmViewVersion(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmViewVersion(this ICakeContext context, NpmViewVersionSettings settings)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(settings);

            AddinInformation.LogVersionInformation(context.Log);
            var tool = new NpmViewVersionTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            return tool.Version(settings);
        }
    }
}