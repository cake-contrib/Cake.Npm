namespace Cake.Npm
{
    using System;
    using Cake.Npm.Ci;
    using Core;
    using Core.Annotations;

    /// <summary>
    /// Npm Ci aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Ci")]
    public static class NpmCiAliases
    {
        /// <summary>
        /// Cis all packages for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmCi();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Ci")]
        public static void NpmCi(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            context.NpmCi(new NpmCiSettings());
        }

        /// <summary>
        /// Cis packages using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Use specific log level ('npm ci')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmCiSettings 
        ///         {
        ///             LogLevel = NpmLogLevel.Verbose
        ///         };
        ///     NpmCi(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Ci")]
        public static void NpmCi(this ICakeContext context, NpmCiSettings settings)
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
            var ciTool = new NpmCiTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            ciTool.Install(settings);
        }
    }
}