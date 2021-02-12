
namespace Cake.Npm.Tests.BumpVersion
{
    using Cake.Npm.BumpVersion;

    internal sealed class NpmBumpVersionToolFixture : NpmFixture<NpmBumpVersionSettings>
    {
        protected override void RunTool()
        {
            var tool = new NpmBumpVersionTool(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.BumpVersion(Settings);
        }
    }
}
