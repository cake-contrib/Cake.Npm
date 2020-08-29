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
        ///     var versionString = NpmVersion();
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
            
            AddinInformation.LogVersionInformation(context.Log);
            var settings = new NpmVersionSettings
            {
                RedirectStandardOutput = true
            };
            return new NpmVersionTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log).Version(settings);
        }
    }
}