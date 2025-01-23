namespace Cake.Npm.Tests.Version;

using System.Text;
using Cake.Npm.Version;

internal sealed class NpmVersionToolFixture : NpmFixture<NpmVersionSettings>
{
    public NpmVersionToolFixture()
    {
    }

    protected override void RunTool()
    {
        var tool = new NpmVersionTool(FileSystem, Environment, ProcessRunner, Tools, Log);
        Version = tool.Version(Settings);
    }

    public string Version { get; private set; }
}
