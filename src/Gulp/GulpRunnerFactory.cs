using Cake.Core;
using Cake.Core.IO;

namespace Cake.Npm.Gulp
{
    public class GulpRunnerFactory
    {
        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IProcessRunner _processRunner;
        private readonly IGlobber _globber;

        internal GulpRunnerFactory(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner,
            IGlobber globber)
        {
            _fileSystem = fileSystem;
            _environment = environment;
            _processRunner = processRunner;
            _globber = globber;
        }

        public GulpRunner Local => new GulpLocalRunner(_fileSystem, _environment, _processRunner, _globber);
        public GulpRunner Global => new GulpGlobalRunner(_fileSystem, _environment, _processRunner, _globber);
    }
}