namespace Cake.Npm.Tests.Rebuild
{
    using Npm.Rebuild;

    internal sealed class NpmRebuilderFixture : NpmFixture<NpmRebuildSettings>
    {
        protected override void RunTool()
        {
            var tool = new NpmRebuilder(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Rebuild(Settings);
        }
    }
}
