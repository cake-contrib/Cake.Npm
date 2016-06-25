using System;
using Cake.Core;
using Cake.Core.Annotations;

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
        /// Task("Npm-Install")
        ///     .Does(() =>
        /// {
        ///     Npm.Install();
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
        ///     Npm.Install("./alternate-working-directory");
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
        ///     Npm.Install(settings => settings.Package("gulp"), "./alternate-working-directory");
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
        ///     Npm.Install(settings => settings.Package("gulp").Globally(), "./alternate-working-directory");
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
        ///     Npm.Install(settings => settings.ForProduction(), "./alternate-working-directory");
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
        ///     Npm.Install(settings => settings.Force(), "./alternate-working-directory");
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
        ///     Npm.RunScript("hello", "./alternate-working-directory");
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm run arguments -- -debug "arg-value.file"'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-RunScript-WithArgs")
        ///     .Does(() =>
        /// {
        ///     Npm.RunScript("arguments", settings => settings.WithArgument("-debug").WithArgument("arg-value.file"), "./alternate-working-directory");
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias]
        public static NpmRunner Npm(this ICakeContext context)
        {
            if(context == null) throw new ArgumentNullException(nameof(context));

            return new NpmRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools);
        }
    }
}