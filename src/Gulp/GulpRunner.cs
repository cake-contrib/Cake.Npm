using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Npm.Gulp
{
    public abstract class GulpRunner : Tool<GulpRunnerSettings>
    {
        public static GulpRunner GetRunner(bool useGlobal, IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber)
        {
            return new GulpLocalRunner(fileSystem, environment, processRunner, globber);
        }

        protected GulpRunner(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IGlobber globber) : base(fileSystem, environment, processRunner, globber)
        {
        }

        protected override string GetToolName()
        {
            return "Gulp Runner";
        }

        public abstract void Execute();
    }
}