using System;
using Cake.Core;
using Cake.Core.Annotations;
using Cake.Core.IO;

namespace Cake.Npm
{
    /// <summary>
    /// Provides a wrapper around Npm functionality within a Cake build script
    /// </summary>
    [CakeAliasCategory("Npm")]
    public static class NpmRunnerAliases
    {
        /// <summary>
        /// Get an Npm runner
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns></returns>
        /// <example>
        /// <para>Run 'npm install'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-FromPath")
        ///     .Does(() =>
        /// {
        ///     Npm.FromPath("./dir-with-packagejson").Install();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm' with logging level</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-LogLevel")
        ///     .Does(() =>
        /// {
        ///     Npm.WithLogLevel(NpmLogLevel.Silent).Install(settings => settings.Package("package"));
        ///     Npm.WithLogLevel(NpmLogLevel.Warn).Install(settings => settings.Package("package"));
        ///     Npm.WithLogLevel(NpmLogLevel.Info).Install(settings => settings.Package("package"));
        ///     Npm.WithLogLevel(NpmLogLevel.Verbose).Install(settings => settings.Package("package"));
        ///     Npm.WithLogLevel(NpmLogLevel.Silly)
        ///         .Install(settings => settings.Package("package1"))
        ///         .Install(settings => settings.Package("package2"));
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm install'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-Install")
        ///     .Does(() =>
        /// {
        ///     Npm.Install();
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm install gulp'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-Install-Gulp")
        ///     .Does(() =>
        /// {
        ///     Npm.Install(settings => settings.Package("package"));
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm install gulp -g'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-Install-Gulp")
        ///     .Does(() =>
        /// {
        ///     Npm.Install(settings => settings.Package("package").Globally());
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm install --production'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-Install-Production")
        ///     .Does(() =>
        /// {
        ///     Npm.Install(settings => settings.ForProduction());
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm install --force'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-Install-Force")
        ///     .Does(() =>
        /// {
        ///     Npm.Install(settings => settings.Force());
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm run hello'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-RunScript")
        ///     .Does(() =>
        /// {
        ///     Npm.RunScript("hello");
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias]
        public static NpmRunner Npm(this ICakeContext context)
        {
            if(context == null) throw new ArgumentNullException(nameof(context));

            return new NpmRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log.Verbosity);
        }
    }
}