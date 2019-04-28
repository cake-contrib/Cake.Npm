namespace Cake.Npm
{
    using System;
    using Cake.Core;
    using Cake.Core.Annotations;
    using Cake.Npm.DistTag;

    /// <summary>
    /// Aliases for Npm distribution tags.
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.DistTag")]
    public static class NpmDistTagsAliases
    {
        /// <summary>
        /// Adds a distribution tag to a specific version of a package.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of the package to which the tag should be applied.</param>
        /// <param name="packageVersion">Version of the package to which the tag should point.</param>
        /// <param name="tag">Tag which should be applied.</param>
        /// <example>
        /// <para>Tags version <c>1.2.3</c> of the package <c>mypackage</c> with the tag <c>stable</c>.</para>
        /// <code>
        /// <![CDATA[
        ///     NpmDistTagAdd("mypackage", "1.2.3", "stable");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagAdd(
            this ICakeContext context,
            string packageName,
            string packageVersion,
            string tag)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(packageVersion))
            {
                throw new ArgumentNullException(nameof(packageVersion));
            }

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            var settings =
                new NpmDistTagAddSettings(packageName, packageVersion)
                {
                    Tag = tag
                };

            context.NpmDistTagAdd(settings);
        }

        /// <summary>
        /// Adds a distribution tag to a specific version of a package using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of the package to which the tag should be applied.</param>
        /// <param name="packageVersion">Version of the package to which the tag should point.</param>
        /// <param name="configurator">The configurator.</param>
        /// <example>
        /// <para>Tags version <c>1.2.3</c> of the package <c>mypackage</c> with the tag <c>stable</c> and uses verbose logging.</para>
        /// <code>
        /// <![CDATA[
        ///     NpmDistTagAdd(
        ///         "mypackage",
        ///         "1.2.3",
        ///         settings => settings.WithTag("stable").WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagAdd(
            this ICakeContext context,
            string packageName,
            string packageVersion,
            Action<NpmDistTagAddSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(packageVersion))
            {
                throw new ArgumentNullException(nameof(packageVersion));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }


            var settings = new NpmDistTagAddSettings(packageName, packageVersion);
            configurator(settings);
            context.NpmDistTagAdd(settings);
        }

        /// <summary>
        /// Adds a distribution tag to a specific version of a package using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Tags version <c>1.2.3</c> of the package <c>mypackage</c> with the tag <c>stable</c> and uses verbose logging.</para>
        /// <code>
        /// <![CDATA[
        ///     var settings =
        ///         new NpmDistTagAddSettings("mypackage", "1.2.3")
        ///         {
        ///             Tag = "stable",
        ///             LogLevel = NpmLogLevel.Verbose
        ///         }
        ///         
        ///     NpmDistTagAdd(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagAdd(
            this ICakeContext context,
            NpmDistTagAddSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null) 
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var tool =
                new NpmDistTagTool(
                    context.FileSystem,
                    context.Environment,
                    context.ProcessRunner,
                    context.Tools, context.Log);
            tool.RunDistTag(settings);
        }

        /// <summary>
        /// Removes a distribution tag from a package.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of the package for which the tag should be removed.</param>
        /// <param name="tag">Tag which should be removed.</param>
        /// <example>
        /// <para>Removes tag <c>stable</c> from the package <c>mypackage</c>.</para>
        /// <code>
        /// <![CDATA[
        ///     NpmDistTagRemove("mypackage", "stable");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagRemove(
            this ICakeContext context,
            string packageName,
            string tag)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            var settings = new NpmDistTagRemoveSettings(packageName, tag);

            context.NpmDistTagRemove(settings);
        }

        /// <summary>
        /// Removes a distribution tag for a package using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of the package to which the tag should be applied.</param>
        /// <param name="tag">Tag which should be removed.</param>
        /// <param name="configurator">The configurator.</param>
        /// <example>
        /// <para>Removes tag <c>stable</c> from the package <c>mypackage</c> using verbose logging.</para>
        /// <code>
        /// <![CDATA[
        ///     NpmDistTagRemove(
        ///         "mypackage",
        ///         "stable",
        ///         settings => settings.WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagRemove(
            this ICakeContext context,
            string packageName,
            string tag,
            Action<NpmDistTagRemoveSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }


            var settings = new NpmDistTagRemoveSettings(packageName, tag);
            configurator(settings);
            context.NpmDistTagRemove(settings);
        }

        /// <summary>
        /// Removes a distribution tag from a package using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Removes tag <c>stable</c> from the package <c>mypackage</c> using verbose logging.</para>
        /// <code>
        /// <![CDATA[
        ///     var settings =
        ///         new NpmDistTagAddSettings("mypackage", "stable")
        ///         {
        ///             LogLevel = NpmLogLevel.Verbose
        ///         }
        ///         
        ///     NpmDistTagAdd(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagRemove(
            this ICakeContext context,
            NpmDistTagRemoveSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var tool =
                new NpmDistTagTool(
                    context.FileSystem,
                    context.Environment,
                    context.ProcessRunner,
                    context.Tools, context.Log);
            tool.RunDistTag(settings);
        }

        /// <summary>
        /// Lists distribution tags for a package.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName">Name of the package whose distribution tags should be listed.</param>
        /// <example>
        /// <para>Lists distribution tags for the package <c>mypackage</c>.</para>
        /// <code>
        /// <![CDATA[
        ///     NpmDistTagList("mypackage");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagList(
            this ICakeContext context,
            string packageName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            var settings =
                new NpmDistTagListSettings
                {
                    PackageName = packageName
                };

            context.NpmDistTagList(settings);
        }

        /// <summary>
        /// List distribution tags using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The configurator.</param>
        /// <example>
        /// <para>Lists distribution tags for the package <c>mypackage</c> using verbose logging.</para>
        /// <code>
        /// <![CDATA[
        ///     NpmDistTagList(settings => settings.ForPackage("mypackage").WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagList(
            this ICakeContext context,
            Action<NpmDistTagListSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }


            var settings = new NpmDistTagListSettings();
            configurator(settings);
            context.NpmDistTagList(settings);
        }

        /// <summary>
        /// Lists distribution tags using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Lists distribution tags for the package <c>mypackage</c> using verbose logging.</para>
        /// <code>
        /// <![CDATA[
        ///     var settings =
        ///         new NpmDistTagAddSettings
        ///         {
        ///             Package = "mypackage",
        ///             LogLevel = NpmLogLevel.Verbose
        ///         }
        ///         
        ///     NpmDistTagAdd(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Distribution Tags")]
        public static void NpmDistTagList(
            this ICakeContext context,
            NpmDistTagListSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var tool =
                new NpmDistTagTool(
                    context.FileSystem,
                    context.Environment,
                    context.ProcessRunner,
                    context.Tools, context.Log);
            tool.RunDistTag(settings);
        }
    }
}
