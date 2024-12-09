using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;
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
        /// Creates a npm package from the current working directory.
        /// Package will be created in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>List of created packages.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPack();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static IEnumerable<FilePath> NpmPack(this ICakeContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            return context.NpmPack(new NpmPackSettings());
        }

        /// <summary>
        /// Creates a npm package from a specific source.
        /// Package will be created in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="source">Source to pack. Can be anything that is installable by npm, like
        /// a package folder, tarball, tarball url, name@tag, name@version, name, or scoped name.</param>
        /// <returns>List of created packages.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPack("c:\mypackagesource");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static IEnumerable<FilePath> NpmPack(this ICakeContext context, string source)
        {
            ArgumentNullException.ThrowIfNull(context);

            if (String.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            return context.NpmPack(new NpmPackSettings { Source = source });
        }

        /// <summary>
        /// Creates a npm package using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <returns>List of created packages.</returns>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPack(settings => settings.WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Pack")]
        public static IEnumerable<FilePath> NpmPack(this ICakeContext context, Action<NpmPackSettings> configurator)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(configurator);

            var settings = new NpmPackSettings();
            configurator(settings);
            return context.NpmPack(settings);
        }

        /// <summary>
        /// Creates a npm package using the specified settings.
        /// Package will be created in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <returns>List of created packages.</returns>
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
        public static IEnumerable<FilePath> NpmPack(this ICakeContext context, NpmPackSettings settings)
        {
            ArgumentNullException.ThrowIfNull(context);

            ArgumentNullException.ThrowIfNull(settings);

            AddinInformation.LogVersionInformation(context.Log);

            var packer = new NpmPacker(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            return packer.Pack(settings);
        }
    }
}