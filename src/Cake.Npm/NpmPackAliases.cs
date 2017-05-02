using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.Pack;

namespace Cake.Npm
{
    /// <summary>
    /// Npm Pack aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Pack")]
    public static class NpmPackAliases
    {
        /// <summary>
        /// Creates a npm package from the current folder.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPack();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static void NpmPack(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.NpmPack(new NpmPackSettings());
        }

        /// <summary>
        /// Creates a npm package from a specific source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="source">Source to pack. Can be anything that is installable by npm, like
        /// a package folder, tarball, tarball url, name@tag, name@version, name, or scoped name.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPack("c:\mypackagesource");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static void NpmPack(this ICakeContext context, string source)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (String.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            context.NpmPack(new NpmPackSettings { Source = source });
        }

        /// <summary>
        /// Creates a npm package using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmPackSettings 
        ///         {
        ///             LogLevel = NpmLogLevel.Verbose
        ///         };
        ///     NpmPack(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static void NpmPack(this ICakeContext context, NpmPackSettings settings)
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

            var packer = new NpmPacker(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            packer.Pack(settings);
        }
    }
}