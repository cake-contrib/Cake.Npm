namespace Cake.Npm.Tests.Pack;

using Npm.Pack;

internal sealed class NpmPackerFixture : NpmFixture<NpmPackSettings>
{
    public NpmPackerFixture()
    {
    }

    protected override void RunTool()
    {
        var tool = new NpmPacker(FileSystem, Environment, ProcessRunner, Tools, Log);
        tool.Pack(Settings);
    }
}
