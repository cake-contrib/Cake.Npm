using Cake.Core;
using Cake.Core.Annotations;
using Cake.Npm.Get;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cake.Npm
{
    /// <summary>
    /// Npm get aliases
    /// </summary>
    [CakeAliasCategory("Npm")]
    [CakeNamespaceImport("Cake.Npm")]
    public static class NpmGetAliases
    {
        /// <summary>
        /// Gets the npm config on the given key
        /// </summary>
        /// <param name="context">The cake context.</param>
        /// <param name="key">The config key.</param>
        /// <param name="workingDirectory">The working directory</param>
        /// <returns>The value on the given key.</returns>
        [CakeMethodAlias]
        [CakeAliasCategory("Get")]
        public static string NpmGet(this ICakeContext context, string key, string workingDirectory = null)
        {
            if (key == null)
            {
                throw new ArgumentNullException("key can't be null");
            }
            NpmGetSettings settings = new NpmGetSettings()
            {
                Key = key,
                WorkingDirectory = workingDirectory
            };
            return new NpmGetTools(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, context.Log).Get(settings);
        }
    }
}
