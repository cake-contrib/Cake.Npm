using System;
using System.IO;
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
        ///     Npm.Install(settings => settings.Package("gulp"));
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
        ///     Npm.Install(settings => settings.Package("gulp").Globally());
        /// });
        /// ]]>
        /// </code>
        /// <para>Run 'npm install --production'</para>
        /// <para>Cake task:</para>
        /// <code>
        /// <![CDATA[
        /// Task("Npm-Install-Gulp")
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
        /// Task("Npm-Install-Gulp")
        ///     .Does(() =>
        /// {
        ///     Npm.Install(settings => settings.Force());
        /// });
        /// ]]>
        /// </code>
        /// </example>
        [CakePropertyAlias]
        public static NpmRunner Npm(this ICakeContext context)
        {
            if(context == null) throw new ArgumentNullException(nameof(context));

            return new NpmRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
        }

	    [CakeMethodAlias]
	    public static NpmPackage NpmPackage(this ICakeContext context)
	    {
		    if (!System.IO.File.Exists("package.json")) throw new FileNotFoundException($"Could not locate package.json in '{Environment.CurrentDirectory}'");
			var parser = new NpmPackageParser();
		    var package = parser.ParseFromFile(new FilePath(System.IO.Path.Combine(Environment.CurrentDirectory, "package.json")));
		    return package;
	    }

	    [CakeMethodAlias]
	    public static NpmPackage NpmPackage(this ICakeContext context, DirectoryPath packageDir)
	    {
		    var oldDir = Environment.CurrentDirectory;
			Environment.CurrentDirectory = packageDir.FullPath;
			var package = NpmPackage(context);
		    Environment.CurrentDirectory = oldDir;
		    return package;
	    }
    }
}