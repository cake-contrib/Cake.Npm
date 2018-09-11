namespace Cake.Npm
{
    using System;
    using Cake.Npm.Set;
    using Core;
    using Core.Annotations;

    /// <summary>
    /// Npm Set aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Set")]
    public static class NpmSetAliases
    {
        /// <summary>
        /// Sets an npm configuration setting.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        /// <param name="global">Set globally</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmSet("progress", "false");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Set")]
        public static void NpmSet(this ICakeContext context, string key, string value, bool global = false)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            
            context.NpmSet(new NpmSetSettings()
            {
                Key = key,
                Value = value,
                Global = global
            });
        }

        /// <summary>
        /// Sets an npm configuration setting returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para>Use speSetfic log level ('npm Set')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmSet(settings => settings.ForKey("progress").WithValue("false"));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Set")]
        public static void NpmSet(this ICakeContext context, Action<NpmSetSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new NpmSetSettings();
            configurator(settings);
            context.NpmSet(settings);
        }

        /// <summary>
        /// Sets an npm configuration setting.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Use speSetfic log level ('npm Set')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = new NpmSetSettings();
        ///     settings.Key = "progress";
        ///     settings.Value = "false";
        ///     NpmSet(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Set")]
        public static void NpmSet(this ICakeContext context, NpmSetSettings settings)
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
            var tool = new NpmSetTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);

            tool.Set(settings);
        }
    }
}