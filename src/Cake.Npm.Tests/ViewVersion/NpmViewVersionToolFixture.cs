
namespace Cake.Npm.Tests.ViewVersion;

using Cake.Npm.ViewVersion;

internal sealed class NpmViewVersionToolFixture : NpmFixture<NpmViewVersionSettings>
{
    internal string Version { get; private set; }

    protected override void RunTool()
    {
        var tool = new NpmViewVersionTool(FileSystem, Environment, ProcessRunner, Tools, Log);
        Version = tool.Version(Settings);
    }
}
