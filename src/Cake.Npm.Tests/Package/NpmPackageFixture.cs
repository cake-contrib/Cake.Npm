using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
using static Cake.Npm.Tests.Properties.Resources;

namespace Cake.Npm.Tests.Package
{
    internal sealed class NpmPackageFixture
    {
        public NpmPackageFixture()
        {
            PackageFilePath = "/Working/package.json";

            var environment = FakeEnvironment.CreateUnixEnvironment();
            Environment = environment;
            var fileSystem = new FakeFileSystem(environment);
            fileSystem.CreateFile(PackageFilePath.FullPath).SetContent(SamplePackageJson);
            FileSystem = fileSystem;
        }

        public ICakeEnvironment Environment { get; set; }

        public NpmPackage Parse(FilePath path = null)
        {
            var parser = new NpmPackageParser(FileSystem, Environment);
            return parser.ParseFromFile(path ?? PackageFilePath);
        }

        public IFileSystem FileSystem { get; set; }
        public FilePath PackageFilePath { get; set; }
    }
}
