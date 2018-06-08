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
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            context.NpmUpdate(new NpmUpdateSettings());
        }

        /// <summary>
        /// Updates packages using the speUpdatefied settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Use speUpdatefic log level ('npm Update')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new NpmUpdateSettings();
        ///     NpmUpdate(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Update")]
        public static void NpmUpdate(this ICakeContext context, NpmUpdateSettings settings)
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
            var tool = new NpmUpdateTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            tool.Update(settings);
        }
    }
}