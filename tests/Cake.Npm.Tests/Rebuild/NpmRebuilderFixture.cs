using Cake.Npm.Rebuild;

namespace Cake.Npm.Tests.Rebuild
{
    internal sealed class NpmRebuilderFixture : NpmFixture<NpmRebuildSettings>
    {
        protected override void RunTool()
        {
            var tool = new NpmRebuilder(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Rebuild(Settings);
        }
    }
}
