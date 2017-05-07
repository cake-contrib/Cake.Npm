using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.RunScript;

namespace Cake.Npm
{
    /// <summary>
    /// Npm RunScript aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.RunScript")]
    public static class NpmRunScriptAliases
    {

        /// <summary>
        /// Runs a npm script defined in the package.json from the current folder.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="scriptName">Name of the script to execute as defined in package.json.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmRunScript("hello");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run-Script")]
        public static void NpmRunScript(this ICakeContext context, string scriptName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (String.IsNullOrWhiteSpace(scriptName))
            {
                throw new ArgumentNullException(nameof(scriptName));
            }

            context.NpmRunScript(
                new NpmRunScriptSettings
                {
                    ScriptName = scriptName
                });
        }

        /// <summary>
        /// Runs a npm script defined in the package.json from the current folder with specific arguments.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="scriptName">Name of the script to execute as defined in package.json.</param>
        /// <param name="arguments">Arguments to pass to the target script</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmRunScript("hello", new List<string> { "--foo=bar" });
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run-Script")]
        public static void NpmRunScript(this ICakeContext context, string scriptName, IEnumerable<string> arguments)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (String.IsNullOrWhiteSpace(scriptName))
            {
                throw new ArgumentNullException(nameof(scriptName));
            }

            if (arguments == null)
            {
                throw new ArgumentNullException(nameof(arguments));
            }

            var settings = new NpmRunScriptSettings
            {
                ScriptName = scriptName
            };

            foreach (var argument in arguments)
            {
                settings.Arguments.Add(argument);
            }

            context.NpmRunScript(settings);
        }

        /// <summary>
        /// Runs a npm script using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="scriptName">Name of the script to execute as defined in package.json.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para>Use specific log level</para>
        /// <code>
        /// <![CDATA[
        ///     NpmRunScript("hello", settings => settings.WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run-Script")]
        public static void NpmRunScript(this ICakeContext context, string scriptName, Action<NpmRunScriptSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (String.IsNullOrWhiteSpace(scriptName))
            {
                throw new ArgumentNullException(nameof(scriptName));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new NpmRunScriptSettings { ScriptName = scriptName };
            configurator(settings);
            context.NpmRunScript(settings);
        }

        /// <summary>
        /// Runs a npm script with the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Use specific log level</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmRunScriptSettings 
        ///         {
        ///             ScriptName = "hello"
        ///             LogLevel = NpmLogLevel.Verbose
        ///         };
        ///     NpmRunScript(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Run-Script")]
        public static void NpmRunScript(this ICakeContext context, NpmRunScriptSettings settings)
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

            var packer = new NpmScriptRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            packer.RunScript(settings);
        }
    }
}