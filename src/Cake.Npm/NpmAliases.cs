namespace Cake.Npm
{
    using System;
    using Core;
    using Core.Annotations;
    using Install;
    using Pack;
    using RunScript;
    using System.Collections.Generic;

    /// <summary>
    /// Provides a wrapper around Npm functionality within a Cake build script
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Install")]
    [CakeNamespaceImport("Cake.Npm.Pack")]
    [CakeNamespaceImport("Cake.Npm.RunScript")]
    public static class NpmAliases
    {
        /// <summary>
        /// Installs packages for the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall();
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void NpmInstall(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            context.NpmInstall(new NpmInstallSettings());
        }

        /// <summary>
        /// Install a package to the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packageName"></param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall("gulp");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void NpmInstall(this ICakeContext context, string packageName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrWhiteSpace(packageName))
            {
                throw new ArgumentNullException(nameof(packageName));
            }

            var settings = new NpmInstallSettings();
            settings.AddPackage(packageName);

            context.NpmInstall(settings);
        }

        /// <summary>
        /// Installs packages using the specified settings.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <example>
        /// <para>Install packages in a specific working directory ('npm install')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmInstallSettings 
        ///         {
        ///             WorkingDirectory = "c:\myproject"
        ///         };
        ///     NpmInstall(settings);
        /// ]]>
        /// </code>
        /// <para>Force fetching of remote resources ('npm install --force')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmInstallSettings 
        ///         {
        ///             Force = true
        ///         };
        ///     NpmInstall(settings);
        /// ]]>
        /// </code>
        /// <para>Install gulp globally ('npm install gulp -g')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmInstallSettings 
        ///         {
        ///             Global = true
        ///         };
        ///     settings.AddPackage("gulp");
        ///     NpmInstall(settings);
        /// ]]>
        /// </code>
        /// <para>Ignore devDependencies while installaling packages of the project in the current directory ('npm install --production')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmInstallSettings 
        ///         {
        ///             Production = true
        ///         };
        ///     NpmInstall(settings);
        /// ]]>
        /// </code>
        /// <para>Use specific log level ('npm install')</para>
        /// <code>
        /// <![CDATA[
        ///     var settings = 
        ///         new NpmInstallSettings 
        ///         {
        ///             LogLevel = NpmLogLevel.Verbose
        ///         };
        ///     NpmInstall(settings);
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void NpmInstall(this ICakeContext context, NpmInstallSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var installer = new NpmInstaller(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            installer.Install(settings);
        }

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

            if (string.IsNullOrWhiteSpace(scriptName))
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

            if (string.IsNullOrWhiteSpace(scriptName))
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

            var packer = new NpmScriptRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            packer.RunScript(settings);
        }

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

            if (string.IsNullOrWhiteSpace(source))
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

            var packer = new NpmPacker(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            packer.Pack(settings);
        }
    }
}