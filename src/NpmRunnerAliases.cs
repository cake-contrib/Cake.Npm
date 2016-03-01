using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Npm.Npm
{
    [CakeAliasCategory("Npm")]
    public static class NpmRunnerAliases
    {
        [CakePropertyAlias]
        public static NpmRunner Npm(this ICakeContext context)
        {
            return new NpmRunner(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
        }
    }
}