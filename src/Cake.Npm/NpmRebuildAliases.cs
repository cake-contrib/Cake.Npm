using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.Install;
using Cake.Npm.Rebuild;

namespace Cake.Npm
{
    /// <summary>
    /// Npm Rebuild aliases
    /// </summary>
    [CakeAliasCategory(("Npm"))]
    [CakeNamespaceImport("Cake.Npm.Rebuild")]
    public static class NpmRebuildAliases
    {
        /// <summary>
        /// Rebuilds packages for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmRebuild();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Rebuild")]
        public static void NpmRebuild(this ICakeContext context)
        {
            context.NpmRebuild(new NpmRebuildSettings());
        }

        /// <summary>
        /// Rebuild one or more packages to the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packages">one or more packages</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmRebuild("gulp", "left-pad");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Rebuild")]
        public static void NpmRebuild(this ICakeContext context, params string[] packages)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var settings = new NpmRebuildSettings();
            foreach (var packageName in packages)
            {
                if (!string.IsNullOrWhiteSpace(packageName))
                {
                    settings.AddPackage(packageName);
                }
            }

            context.NpmRebuild(settings);
        }

        /// <summary>
        /// Rebuild packages using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator</param>
        /// <example>
        /// <para>Rebuild packages in a specific working directory ('npm rebuild')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmRebuild(settings => settings.FromPath(@"c:\myproject"));
        /// ]]>
        /// </code>
        /// </example>
        /// <para>Rebuild gulp ('npm rebuild gulp')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmRebuild(settings => settings.AddPackage("gulp"));
        /// ]]>
        /// </code>
        [CakeMethodAlias]
        [CakeAliasCategory("Rebuild")]
        public static void NpmRebuild(this ICakeContext context, Action<NpmRebuildSettings> configurator)
        {
            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new NpmRebuildSettings();
            configurator.Invoke(settings);
            context.NpmRebuild(settings);
        }

        /// <summary>
        /// Rebuilds packages using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Rebuild packages in a specific working directory ('npm rebuild')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmRebuildSettings 
        ///         {
        ///             WorkingDirectory = "c:\myproject"
        ///         };
        ///     NpmRebuild(settings);
        /// ]]>
        /// </code>
        /// <para>Rebuild gulp ('npm rebuild gulp')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmRebuildSettings 
        ///         {
        ///             Global = true
        ///         };
        ///     settings.AddPackage("gulp");
        ///     NpmRebuild(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Rebuild")]
        public static void NpmRebuild(this ICakeContext context, NpmRebuildSettings settings)
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
            var rebuilder = new NpmRebuilder(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            rebuilder.Rebuild(settings);
        }
    }
}