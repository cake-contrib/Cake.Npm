using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm.Gulp
{
    public class GulpGlobalRunner : GulpRunner
    {
        public GulpGlobalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
        }

        public override void Execute()
        {
            var args = new ProcessArgumentBuilder();
            Run(new GulpRunnerSettings(), args);
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "gulp.cmd";
        }
    }
}