namespace Cake.Npm
{
    using System;
    using Cake.Npm.Update;
    using Core;
    using Core.Annotations;

    /// <summary>
    /// Npm Update aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Update")]
    public static class NpmUpdateAliases
    {
        /// <summary>
        /// Updates all packages for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmUpdate();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        public static void NpmUpdate(this ICakeContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.NpmUpdate(new NpmUpdateSettings());
        }

        /// <summary>
        /// Updates all packages for the project using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmUpdate(settings => settings.UpdateGlobalPackages());
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        public static void NpmUpdate(this ICakeContext context, Action<NpmUpdateSettings> configurator)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(configurator);

            var settings = new NpmUpdateSettings();
            configurator(settings);
            context.NpmUpdate(settings);
        }

        /// <summary>
        /// Updates all packages for the project using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var settings = new NpmUpdateSettings();
        ///     settings.UpdateGlobalPackages();
        ///     NpmUpdate(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        public static void NpmUpdate(this ICakeContext context, NpmUpdateSettings settings)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(settings);

            AddinInformation.LogVersionInformation(context.Log);
            var tool = new NpmUpdateTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            tool.Update(settings);
        }
    }
}