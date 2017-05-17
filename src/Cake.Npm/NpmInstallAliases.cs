namespace Cake.Npm
{
    using System;
    using Core;
    using Core.Annotations;
    using Install;

    /// <summary>
    /// Npm Install aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm.Install")]
    public static class NpmInstallAliases
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
        /// Install one or more packages to the project in the current working directory.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="packages">one or more packages</param>
        /// <example>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall("gulp", "left-pad");
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void NpmInstall(this ICakeContext context, params string[] packages)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var settings = new NpmInstallSettings();
            foreach (var packageName in packages)
            {
                if (!String.IsNullOrWhiteSpace(packageName))
                {
                    settings.AddPackage(packageName);
                }
            }

            context.NpmInstall(settings);
        }

        /// <summary>
        /// Installs packages using the settings returned by a configurator.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="configurator">The settings configurator.</param>
        /// <example>
        /// <para>Install packages in a specific working directory ('npm install')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall(settings => settings.FromPath(@"c:\myproject"));
        /// ]]>
        /// </code>
        /// <para>Force fetching of remote resources ('npm install --force')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall(settings => setting.WithForce());
        /// ]]>
        /// </code>
        /// <para>Install gulp globally ('npm install gulp -g')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall(settings => settings.AddPackage("gulp").InstallGlobally());
        /// ]]>
        /// </code>
        /// <para>Ignore devDependencies while installaling packages of the project in the current directory ('npm install --production')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall(settings => setting.OnProduction());
        /// ]]>
        /// </code>
        /// <para>Use specific log level ('npm install')</para>
        /// <code>
        /// <![CDATA[
        ///     NpmInstall(settings => settings.WithLogLevel(NpmLogLevel.Verbose));
        /// ]]>
        /// </code>
        /// </example>
        [CakeMethodAlias]
        [CakeAliasCategory("Install")]
        public static void NpmInstall(this ICakeContext context, Action<NpmInstallSettings> configurator)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (configurator == null)
            {
                throw new ArgumentNullException(nameof(configurator));
            }

            var settings = new NpmInstallSettings();
            configurator(settings);
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

            AddinInformation.LogVersionInformation(context.Log);
            var installer = new NpmInstaller(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log);
            installer.Install(settings);
        }
    }
}