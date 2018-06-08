namespace Cake.Npm
{
    using System;
    using Cake.Npm.Version;
    using Core;
    using Core.Annotations;

    /// <summary>
    /// Npm Version aliases
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
        ///     NpmVersion();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmVersion(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            return context.NpmVersion(new NpmVersionSettings());
        }

        /// <summary>
        /// Versions packages using the speVersionfied settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Use speVersionfic log level ('npm Version')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new NpmVersionSettings();
        ///     NpmVersion(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Version")]
        public static string NpmVersion(this ICakeContext context, NpmVersionSettings settings)
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
            var VersionTool = new NpmVersionTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            return VersionTool.Version(settings);
        }
    }
}