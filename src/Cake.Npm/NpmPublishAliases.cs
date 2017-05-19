using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.Publish;

namespace Cake.Npm
{
    /// <summary>
    /// Npm publish aliases.
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Publish")]
    public static class NpmPublishAliases
    {
        /// <summary>
        /// Publishes the npm package in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPublish();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        public static void NpmPublish(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.NpmPublish(new NpmPublishSettings());
        }

        /// <summary>
        /// Publishes the npm package created from a specific source.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="source">Source to publish.
        /// A folder containing a package.json file or an url or file path to a gzipped tar archive 
        /// containing a single folder with a package.json file inside.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPublish("c:\mypackagesource");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        public static void NpmPublish(this ICakeContext context, string source)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (String.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException(nameof(source));
            }

            context.NpmPublish(new NpmPublishSettings { Source = source });
        }

        /// <summary>
        /// Publishes a npm package using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmPack(settings => settings.WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        public static void NpmPublish(this ICakeContext context, Action<NpmPublishSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new NpmPublishSettings();
            configurator(settings);
            context.NpmPublish(settings);
        }

        /// <summary>
        /// Publishes a npm package based on the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmPublishSettings 
        ///         {
        ///             LogLevel = NpmLogLevel.Verbose,
        ///             Source = "c:\mypackagesource"
        ///         };
        ///     NpmPublish(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Publish")]
        public static void NpmPublish(this ICakeContext context, NpmPublishSettings settings)
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

            var publisher = new NpmPublisher(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            publisher.Publish(settings);
        }
    }
}