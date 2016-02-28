using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm.Gulp
{
    public class GulpLocalRunner : GulpRunner
    {
        public GulpLocalRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
        }

        public override void Execute()
        {
            var args = new ProcessArgumentBuilder();
            args.Append("./node_modules/gulp/bin/gulp.js");
            Run(new GulpRunnerSettings(), args);
        }
        
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "node.exe";
        }
    }
}