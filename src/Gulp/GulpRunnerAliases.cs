using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Npm.Gulp
{
    [CakeAliasCategory("Gulp")]
    public static class GulpRunnerAliases
    {
        [CakePropertyAlias]
        public static GulpRunnerFactory Gulp(this ICakeContext context)
        {
            return new GulpRunnerFactory(context.FileSystem, context.Environment, context.ProcessRunner, context.Globber);
        }
    }
}