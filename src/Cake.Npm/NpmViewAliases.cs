using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Npm
{
    /// <summary>
    /// Npm view aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm")]
    public static class NpmViewAliases
    {
        /// <summary>
        /// Call npm view with --json attribute.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="packageName">Name of the package</param>
        /// <param name="workingDirectory"></param>
        /// <returns>An empty string if the package was not found on the repository</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("View")]
        public static string NpmView(this ICakeContext context, string packageName = null, string workingDirectory = null)
        {
            NpmViewSettings settings = new NpmViewSettings()
            {
                PackageName = packageName,
                WorkingDirectory = workingDirectory
            };
            return new NpmViewTool(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log).View(settings);
        }
    }
}
